using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleRotation : MonoBehaviour
{
    //Enemies need a different starting particle rotation for some reason. Orient the particles based on origin rotation.
    ParticleSystem sys;
    public bool isEnemy;
    // Start is called before the first frame update
    void Start()
    {
        sys = GetComponent<ParticleSystem>();
    }

    // Update is called once per frame
    void Update()
    {
        var main = sys.main;
        if (isEnemy)
        {
            main.startRotation = -(transform.rotation.eulerAngles.z - 90f) * Mathf.Deg2Rad;
        }
        else
        {
            main.startRotation = (transform.rotation.eulerAngles.z - 90f) * Mathf.Deg2Rad;
        }
    }
}
