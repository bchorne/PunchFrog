//https://www.youtube.com/watch?v=TO7ZNNOJgrU

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpObject : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        PlayerMovement p = collision.GetComponent<PlayerMovement>();

        if (p != null)
        {
            GetComponent<IPickUp>().OnPickUp(p);
        }
    }
}
