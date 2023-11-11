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

    public int spreadCount = 1;

    private void Start()
    {
        sys = GetComponent<ParticleSystem>();
    }

    private void OnParticleCollision(GameObject other)
    {
        if (other.TryGetComponent<Damageable>(out Damageable thing)) //Sanity check for a damageable thing
        {
            thing.takeDamage(Damage);
        }

        if (other.TryGetComponent<Enemy>(out Enemy enemy)) //Apply knockback only to an Enemy
        {
            enemy.TakeKnockback((enemy.transform.position - transform.position).normalized);
            //Lifesteal Check Here
            if (lifesteal)
            {
                player.takeDamage(Mathf.RoundToInt(-Damage * 0.4f));
            }
        }
    }

    public void ChangeRate(float rate) //Set the duration of the emitter based on the rate
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

    public void IncreaseSpread() //Add extra bullets to our shot
    {
        spreadCount++;

        sys.Stop(true, ParticleSystemStopBehavior.StopEmittingAndClear);

        //Get and set an extra bullet
        var shape = sys.shape;
        ParticleSystem.Burst burst = sys.emission.GetBurst(0);
        ParticleSystem.MinMaxCurve cons = burst.count;
        cons.constant = cons.constant + 1;
        burst.count = cons;
        sys.emission.SetBurst(0, burst);

        //Change the arc of our spread to accomodate for the extra projectiles.
        switch(spreadCount)
        {
            case 2: //Adding our first extra bullet
                shape.arc = 8;
                shape.rotation = new Vector3(shape.rotation.x, shape.rotation.y, -94);
                break;
            case 3:
                shape.arc = 20;
                shape.rotation = new Vector3(shape.rotation.x, shape.rotation.y, -100);
                break;
            case 4:
            case 5:
                shape.arc = 30;
                shape.rotation = new Vector3(shape.rotation.x, shape.rotation.y, -105);
                break;
            default: //Additional particles beyond the 5th
                shape.arc = 40;
                shape.rotation = new Vector3(shape.rotation.x, shape.rotation.y, -110);
                break;
        }

        sys.Play();
    }
}
