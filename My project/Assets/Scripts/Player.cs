using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public PlayerLevel level;
    public BulletParticles weapon;
    public Damageable health;
    public PlayerMovement movement;
    public CircleCollider2D magnet;

    public int damage; //Base Damage
    public float dmgMulti; //Total bonus damage from upgrades
    public int maxHealth;
    public float speed;
    public float magnetRadius;
    public float shotsPerSecond;
    public float expMultiplier;

    private void Start()
    {
        //Init values
        health.maxHealth = maxHealth;
        health.currentHealth = maxHealth;
        UpdateDamage();
        UpdateHealth();
        UpdateRateOfFire();
        UpdateMagnet();
        UpdateSpeed();
        UpdateLearning();
    }


    public void UpdateDamage()
    {
        weapon.Damage = (int)(damage * dmgMulti);
    }

    public void UpdateHealth()
    {
        health.currentHealth += maxHealth - health.maxHealth;
        health.maxHealth = maxHealth;
    }

    public void UpdateSpeed()
    {
        movement.moveSpeed = speed;
    }

    public void UpdateMagnet()
    {
        magnet.radius = magnetRadius;
    }

    public void UpdateRateOfFire()
    {
        weapon.ChangeRate(shotsPerSecond);
    }

    public void UpdateLearning()
    {
        level.bonusExp = expMultiplier;
    }
}
