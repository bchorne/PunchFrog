//Magnet Behaviour: https://youtu.be/x8_LJ22QnlE?si=C2Mbpq_G_4vboD3S

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collector : MonoBehaviour
{
    private void OnTriggerStay2D(Collider2D collision)
    {
        if(collision.TryGetComponent<ExpPickUp>(out ExpPickUp pickUp))
        {
            pickUp.SetTarget(transform.parent.position);
        }
    }
}
