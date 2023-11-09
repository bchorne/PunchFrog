using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletParticles : MonoBehaviour
{
    public ParticleSystem sys;

    public int Damage;

    public bool lifesteal;

    List<ParticleCollisionEvent> colEvents = new List<ParticleCollisionEvent>();

    public Damageable player;

    private void Start()
    {
        sys = GetComponent<ParticleSystem>();
    }

    private void OnParticleCollision(GameObject other)
    {
        int events = sys.GetCollisionEvents(other, colEvents);

        //for (int i = 0; i < events; i++)
        //{

        //}

        if (other.TryGetComponent<Damageable>(out Damageable thing))
        {
            thing.takeDamage(Damage);
        }

        if (other.TryGetComponent<Enemy>(out Enemy enemy))
        {
            enemy.TakeKnockback((enemy.transform.position - transform.position).normalized);
            //Lifesteal Check Here
            if (lifesteal)
            {
                player.takeDamage(Mathf.RoundToInt(-Damage * 0.4f));
            }
        }
    }

    public void ChangeRate(float rate)
    {
        sys.Stop(true, ParticleSystemStopBehavior.StopEmittingAndClear);

        var main = sys.main;
        main.duration = 1 / rate;

        sys.Play();
    }

    public void IncreaseBurst() //BurstFire Increase
    {
        sys.Stop(true, ParticleSystemStopBehavior.StopEmittingAndClear);

        ParticleSystem.Burst burst = sys.emission.GetBurst(0);
        burst.cycleCount++;
        sys.emission.SetBurst(0, burst);

        sys.Play();
    }
}
