using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShadowLock : MonoBehaviour
{
    public Rigidbody rb;
    public Vector3 lockedPosition;
    
    void Update()
    {
        transform.position = lockedPosition;
    }
}
