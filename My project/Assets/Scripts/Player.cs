//Base player class. Mostly executes upgrades between its component parts.
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public PlayerLevel level;
    public BulletParticles weapon; //Primary weapon system
    public BulletParticles backshot; //Back Shot weapon, unocked via upgrade
    public GameObject back; //For turning backshot on
    public Damageable health;
    public PlayerMovement movement;
    public CircleCollider2D magnet; //Larger collider for picking up exp gems at a distance
    public SpaceOrbitals orbits; //For telling orbitals to spawn.
    public GameObject laser; //Laser prefab

    public int damage; //Base Damage
    public float dmgMulti; //Total bonus damage from upgrades
    public int maxHealth;
    public float speed;
    public float magnetRadius;
    public float shotsPerSecond;
    public float expMultiplier;
    public bool retaliate = false;

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


    public void UpdateDamage() //Set the damage values for our weapons
    {
        weapon.Damage = (int)(damage * dmgMulti);
        backshot.Damage = (int)(damage * dmgMulti);
        orbits.sawDamage = (int)(damage * dmgMulti * 0.4);
    }

    public void UpdateHealth() //If there is a difference in our max health, heal for that difference. then, set new max health.
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
        backshot.lifesteal = true;
    }

    public void ShotAmountIncrease()
    {
        weapon.IncreaseSpread();
    }

    public void AddOrbital()
    {
        orbits.AddOrbital();
    }

    public void EnableBackShot()
    {
        back.SetActive(true);
    }

    public void StartLaser()
    {
        InvokeRepeating("FireLaser", 1, 5);
    }

    public void EnableRetaliate()
    {
        retaliate = true;
    }

    public void AddDefense()
    {
        health.defense = Mathf.Clamp(health.defense -= 0.1f, 0.4f, 1); //Increase our defense, capping at 60% dmg resistance.
    }

    public void FireLaser() //Gets all enemies aimed at, damages them
    {
        Instantiate(laser, transform.position, transform.rotation); //Create the laser sprite, which fades itself out.
        
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
