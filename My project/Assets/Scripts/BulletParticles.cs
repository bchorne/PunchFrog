using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletParticles : MonoBehaviour
{
    public ParticleSystem sys;

    public int Damage;

    List<ParticleCollisionEvent> colEvents = new List<ParticleCollisionEvent>();

    private void Start()
    {
        sys = GetComponent<ParticleSystem>();
    }

    private void OnParticleCollision(GameObject other)
    {
        int events = sys.GetCollisionEvents(other, colEvents);

        for (int i = 0; i < events; i++)
        {

        }

        if (other.TryGetComponent<Enemy>(out Enemy en))
        {
            en.takeDamage(Damage);
        }
    }

    public void Fire()
    {
        sys.Play();
    }
}