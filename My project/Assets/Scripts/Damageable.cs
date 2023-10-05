using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damageable : MonoBehaviour
{
    public int maxHealth;
    public int currentHealth;

    public bool isPlayer;
    public GameObject DamageNum;

    public void takeDamage(int damageIn)
    {
        currentHealth -= damageIn;
        GameObject tmp = Instantiate(DamageNum, new Vector3(transform.position.x, transform.position.y, 10), Quaternion.identity);
        tmp.GetComponent<DamageNumber>().text.text = damageIn.ToString();

        if (currentHealth <= 0)
        {
            if (isPlayer)
            {
                //Game Over
                Debug.Log("Dead!");
            }
            else //Must be enemy; get its enemy and run Die
            {
                GetComponent<Enemy>().Die();
            }
        }
    }
}
