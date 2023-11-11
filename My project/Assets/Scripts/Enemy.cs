//Base class for an enemy entity.

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
    public Damageable damageable;

    private Player player;
    private Rigidbody2D rb;
    private bool knockback;
    private float kbTimer; //How long to stay "stunned"
    private float meleeTimer; //Delay between melee strikes.
    private float sawTimer; //Time between saw hits, prevents saw from killing each frame

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
        damageable = GetComponent<Damageable>();
    }

    private void FixedUpdate()
    {
        if (player != null) //Face the player
        {
            Vector2 LookAt = new Vector2(player.transform.position.x, player.transform.position.y) - rb.position;
            float angle = Mathf.Atan2(LookAt.y, LookAt.x) * Mathf.Rad2Deg + 90f;
            rb.rotation = angle;
        }

        float distanceToPlayer = Vector3.Distance(rb.position, player.transform.position);

        if (!knockback)
        {
            //Move towards player, don't get too close if Ranged type enemy
            if (!(type == EnemyType.ranged) || (type == EnemyType.ranged && distanceToPlayer > approachDistance))
            {
                rb.velocity = ((new Vector2(player.transform.position.x, player.transform.position.y) - rb.position).normalized * speed);
            }
            else
            {
                rb.velocity = Vector2.zero;
            }
        }
        else //Run knockback timer while knockedback
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

        if (sawTimer >= 0)
        {
            sawTimer -= Time.deltaTime;
        }
    }

    public void Die()
    {
        //Drop Exp Gem
        GameObject tmp = Instantiate(ExpDrop, transform.position, Quaternion.identity);
        tmp.GetComponent<ExpPickUp>().amount = ExpReward;
        
        //Remove from target reference
        gm.enemies.Remove(this);

        //Return to object pool
        gameObject.SetActive(false);
    }

    public void TakeKnockback(Vector3 direction) //Stop regular movement and force movement in a given direction
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
            if (p.retaliate)
            {
                damageable.takeDamage((int)(contactDamage * 0.8f));
            }
        }
    }

    public void Saw(int dmg) //Prevent saws from obliterating enemies each frame
    {
        if (sawTimer <= 0) 
        {
            sawTimer = 0.2f;
            damageable.takeDamage(dmg);
        }
    }
}
