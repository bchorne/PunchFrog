//https://www.youtube.com/watch?v=TO7ZNNOJgrU

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpObject : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Player p = collision.GetComponent<Player>();

        if (p != null)
        {
            GetComponent<IPickUp>().OnPickUp(p);
        }
    }
}
