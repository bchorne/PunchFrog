using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f;

    public Rigidbody2D rb;

    public Joystick joy;

    Vector2 movement;

    // Update is called once per frame
    void Update()
    {
        movement.x = joy.Horizontal;
        movement.y = joy.Vertical;
    }

    private void FixedUpdate()
    {
        rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);
    }
}
