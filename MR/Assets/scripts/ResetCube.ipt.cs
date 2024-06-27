using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetCube : MonoBehaviour
{
    public void ResetObject()
    {
        transform.localRotation = Quaternion.identity;
    }
}