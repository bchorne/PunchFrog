using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public PlayerLevel level;
    public BulletParticles weapon;
    public Damageable health;

    public int damage; //Base Damage
    public float dmgMulti; //Total bonus damage from upgrades
    public int maxHealth;

    private void Start()
    {
        //Init values
        health.maxHealth = maxHealth;
        health.currentHealth = maxHealth;
        UpdateDamage();
    }


    public void UpdateDamage()
    {
        weapon.Damage = (int)(damage * dmgMulti);
    }
}
