using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleRotation : MonoBehaviour
{
    ParticleSystem sys;
    // Start is called before the first frame update
    void Start()
    {
        sys = GetComponent<ParticleSystem>();
    }

    // Update is called once per frame
    void Update()
    {
        var main = sys.main;
        main.startRotation = (transform.rotation.eulerAngles.z - 90f) * Mathf.Deg2Rad;
    }
}
