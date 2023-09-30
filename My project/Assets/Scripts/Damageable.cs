using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damageable : MonoBehaviour
{
    public int maxHealth;
    public int currentHealth;

    public bool isPlayer;

    public void takeDamage(int damageIn)
    {
        currentHealth -= damageIn;

        if (currentHealth <= 0)
        {
            if (isPlayer)
            {
                //Game Over
            }
            else //Must be enemy; get its enemy and run Die
            {
                GetComponent<Enemy>().Die();
            }
        }
    }
}
