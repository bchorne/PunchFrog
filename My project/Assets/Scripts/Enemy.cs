using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int curHealth;
    public int maxHealth;
    public float speed;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        
    }

    public void takeDamage(int damageIn)
    {
        curHealth -= damageIn;

        if (curHealth <= 0)
        {
            gameObject.SetActive(false);
        }
    }
}
