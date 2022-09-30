using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnfreezeXYZ : MonoBehaviour
{
    Rigidbody rb;

  void OnTriggerEnter(Collider other)
    {
        rb.freezeRotation = false;
    }



}

