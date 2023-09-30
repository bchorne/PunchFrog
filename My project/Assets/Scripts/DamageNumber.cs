//https://wintermutedigital.com/post/damage-text-unity/
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DamageNumber : MonoBehaviour
{
    private Color color_i, color_f;
    private Vector3 initialOffset, finalOffset; //position to drift to, relative to the gameObject's local origin
    public float fadeDuration;
    private float fadeStartTime;
    public TextMeshPro text;
    // Start is called before the first frame update
    void Start()
    {
        fadeStartTime = Time.time;
        //Give a slightly random trajectory
        finalOffset.x += Random.Range(-0.1f, 0.1f);
        color_i = text.color;
        color_f = new Color(color_i.r, color_i.g, color_i.b, 0.4f);

        initialOffset = new Vector3(transform.position.x, transform.position.y + 0.3f, 0f);
        finalOffset = new Vector3(transform.position.x, transform.position.y + 0.6f, 0f);
    }

    // Update is called once per frame
    void Update()
    {
        float progress = (Time.time - fadeStartTime) / fadeDuration;
        if (progress <= 1)
        {
            //lerp factor is from 0 to 1, so we use (FadeExitTime-Time.time)/fadeDuration
            transform.localPosition = Vector3.Lerp(initialOffset, finalOffset, progress);
            text.color = Color.Lerp(color_i, color_f, progress);
        }
        else Destroy(gameObject);
    }
}
