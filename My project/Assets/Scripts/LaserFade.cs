using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserFade : MonoBehaviour
{
    public SpriteRenderer img;
    public float rate;

    // Update is called once per frame
    void Update()
    {
        Color tmp = img.color;
        tmp.a -= (rate * Time.deltaTime);
        img.color = tmp;
        if (tmp.a <= 0)
        {
            Destroy(gameObject);
        }
    }
}
