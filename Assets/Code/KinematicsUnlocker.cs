using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KinematicsUnlocker : MonoBehaviour
{
    private Rigidbody rb;

    public void UnlockKinematics() 
    {
        rb = GetComponent<Rigidbody>();
        rb.isKinematic = false;
    }
}
