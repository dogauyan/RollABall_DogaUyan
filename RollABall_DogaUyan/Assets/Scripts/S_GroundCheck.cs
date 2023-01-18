using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class S_GroundCheck : MonoBehaviour
{
    public S_TOPMovement theball;

    private void OnTriggerEnter(Collider other)
    {
        /*if (!ReferenceEquals(other.gameObject, theball.gameObject)) */theball.OnGround = true;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (!ReferenceEquals(collision.gameObject, theball.gameObject)) theball.OnGround = true;
    }

    private void OnTriggerExit(Collider other)
    {
        /*if (!ReferenceEquals(other.gameObject, theball.gameObject)) */theball.OnGround = false;
    }

    private void OnCollisionExit(Collision collision)
    {
        if (!ReferenceEquals(collision.gameObject, theball.gameObject)) theball.OnGround = true;
    }
}
