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

    private void Update()
    {
        //Used for testing
        if (Input.GetKeyDown(KeyCode.Space))
        {
            FireLaser();
        }
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

    public void BurstCountIncrease()
    {
        weapon.IncreaseBurst();
    }

    public void EnableLifesteal()
    {
        weapon.lifesteal = true;
    }

    public void FireLaser() //Gets all enemies aimed at, damages them
    {
        RaycastHit2D[] hits;
        hits = Physics2D.RaycastAll(transform.position, -transform.up, 100f);

        for (int i = 0; i < hits.Length; i++)
        {
            RaycastHit2D hit = hits[i];
            Enemy enemy = hit.transform.GetComponent<Enemy>();

            if (enemy)
            {
                enemy.damageable.takeDamage(Mathf.RoundToInt(damage * dmgMulti * 3));
            }
        }
    }
}
