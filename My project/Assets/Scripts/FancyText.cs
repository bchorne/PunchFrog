using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FancyText : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        float theta = Mathf.Cos(Time.time * 2);
        float epsilon = Mathf.Cos(Time.time * 3) / 720;

        transform.position = new Vector3(transform.position.x, transform.position.y + theta, transform.position.z);
        transform.rotation = new Quaternion(transform.rotation.x, transform.rotation.y, transform.rotation.z + epsilon, transform.rotation.w);
    }
}
