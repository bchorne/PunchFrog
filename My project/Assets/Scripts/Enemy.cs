using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using Unity.VisualScripting;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class Enemy : MonoBehaviour
{
    public float speed;
    public float kbResist; //Multiplier for KB
    public float approachDistance; //How close the unit will get to the player.
    public int contactDamage;

    private Player player;
    private Rigidbody2D rb;
    private bool knockback;
    private float kbTimer;
    private float meleeTimer; //Delay between melee strikes.

    public enum EnemyType { ranged, melee}
    public EnemyType type;

    public GameManager gm;

    public GameObject ExpDrop;
    public int ExpReward;

    void Awake()
    {
        gm = FindObjectOfType<GameManager>();
        player = FindObjectOfType<Player>();
        rb = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        if (player != null) //Face the player
        {
            Vector2 LookAt = new Vector2(player.transform.position.x, player.transform.position.y) - rb.position;
            float angle = Mathf.Atan2(LookAt.y, LookAt.x) * Mathf.Rad2Deg + 90f;
            rb.rotation = angle;
        }

        float distance = Vector3.Distance(rb.position, player.transform.position);

        if (!knockback)
        {
            //Move towards player, don't get too close if Ranged type enemy
            if (!(type == EnemyType.ranged) || (type == EnemyType.ranged && distance > approachDistance))
            {
                rb.velocity = ((new Vector2(player.transform.position.x, player.transform.position.y) - rb.position).normalized * speed);
            }
            else
            {
                rb.velocity = Vector2.zero;
            }
        }
        else
        {
            kbTimer -= Time.deltaTime;
            if (kbTimer <= 0)
            {
                knockback = false;
            }
        }

        if (meleeTimer >= 0)
        {
            meleeTimer -= Time.deltaTime;
        }
    }

    public void Die()
    {
        //Drop Exp Gem
        GameObject tmp = Instantiate(ExpDrop, transform.position, Quaternion.identity);
        tmp.GetComponent<ExpPickUp>().amount = ExpReward;
        
        gm.enemies.Remove(this);

        gameObject.SetActive(false);
    }

    public void TakeKnockback(Vector3 direction)
    {
        knockback = true;
        kbTimer = 0.2f;
        direction.z = 0;

        rb.velocity = Vector2.zero;
        rb.AddForce(direction*kbResist, ForceMode2D.Impulse);
    }

    private void OnCollisionEnter2D(Collision2D collision) //Contact damage with player, primarily for Melee enemies but ranged ones do too.
    {
        Player p = collision.gameObject.GetComponent<Player>();

        if (p != null && meleeTimer <= 0)
        {
            p.health.takeDamage(contactDamage);
            TakeKnockback((transform.position - p.transform.position).normalized); //Push the enemy back
            meleeTimer = 0.2f;

            //IF RETALIATE, DAMAGE ENEMY BACK
        }
    }
}
