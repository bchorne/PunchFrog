//Lerp Camera position towards player position

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public Transform player;

    public Vector2 minPos;
    public Vector2 maxPos;

    public float speed = 0.1f;

    private void FixedUpdate()
    {
        if (transform.position != player.position)
        {
            Vector3 target = new Vector3(player.position.x, player.position.y, transform.position.z);

            //Clamp to our max/min bounds
            target.x = Mathf.Clamp(target.x, minPos.x, maxPos.x);
            target.y = Mathf.Clamp(target.y, minPos.y, maxPos.y);

            //Lerp there
            transform.position = Vector3.Lerp(transform.position, target, speed);
        }
    }
}
