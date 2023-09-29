using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f;
    public Rigidbody2D rb;

    public Joystick joy;

    Vector2 movement;

    public GameManager gm;

    public Enemy target;

    public PlayerLevel level;

    private void Awake()
    {
        gm = FindObjectOfType<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        movement.x = joy.Horizontal;
        movement.y = joy.Vertical;

        //Find Nearest enemy, set them to be our target
        FindNearest();
    }

    private void FixedUpdate()
    {
        rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime); //Move according to input

        if (target != null) //Face nearest enemy
        {
            Vector2 LookAt = new Vector2(target.transform.position.x, target.transform.position.y) - rb.position;
            float angle = Mathf.Atan2(LookAt.y, LookAt.x) * Mathf.Rad2Deg + 90f;
            rb.rotation = angle;
        }
    }

    private void FindNearest()
    {
        Enemy nearest = null;
        float dist = Mathf.Infinity;

        foreach (Enemy enemy in gm.enemies)
        {
            if (enemy.gameObject.activeSelf)
            {
                Vector2 diff = new Vector2(enemy.transform.position.x, enemy.transform.position.y) - rb.position;

                if (diff.sqrMagnitude < dist)
                {
                    nearest = enemy;
                    dist = diff.sqrMagnitude;
                }
            }
        }

        target = nearest;
    }
}
