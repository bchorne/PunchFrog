using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damageable : MonoBehaviour
{
    public int maxHealth;
    public int currentHealth;
    public float defense = 1; //Amount to multiply incoming damage by

    public bool isPlayer;
    public GameObject DamageNum;
    public GameManager GameManager;

    private void Start()
    {
        GameManager = FindObjectOfType<GameManager>();
    }

    public void takeDamage(int damageIn)
    {
        if (isPlayer)
        {
            damageIn = (int)(damageIn * defense);
        }

        currentHealth = Mathf.Clamp(currentHealth - damageIn, 0, maxHealth);
        GameObject tmp = Instantiate(DamageNum, new Vector3(transform.position.x, transform.position.y, 10), Quaternion.identity);
        DamageNumber num = tmp.GetComponent<DamageNumber>();

        num.text.color = (damageIn > 0) ? Color.red : Color.green;

        num.text.text = damageIn.ToString();


        if (currentHealth <= 0)
        {
            if (isPlayer)
            {
                //Game Over
                GameManager.GameOver();
            }
            else //Must be enemy; get its enemy and run Die
            {
                GetComponent<Enemy>().Die();
            }
        }
    }
}
