//https://www.youtube.com/watch?v=TO7ZNNOJgrU

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExpPickUp : MonoBehaviour, IPickUp
{
    public int amount;
    Rigidbody2D rb;

    bool magnet = false;
    Vector3 targetPos;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        transform.position = new Vector3(transform.position.x, transform.position.y, -0.1f);
    }

    public void OnPickUp(Player player)
    {
        player.level.AddXp(amount);
        Destroy(gameObject);
    }

    private void FixedUpdate()
    {
        if (magnet)
        {
            Vector2 targetDir = (targetPos - transform.position).normalized;
            rb.velocity = targetDir * 4f;
        }
    }

    public void SetTarget(Vector3 pos)
    {
        targetPos = pos;
        magnet = true;
    }
}
