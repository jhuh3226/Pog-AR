using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Case5GravityControl : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "pogBot")
        { // if player entered the trigger...
            other.attachedRigidbody.useGravity = true;
        }
    }
}
