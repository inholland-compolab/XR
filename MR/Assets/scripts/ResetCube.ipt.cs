using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetCube : MonoBehaviour
{
    public void ResetObject()
    {
        transform.rotation = Quaternion.Euler(0, 0, 0);
    }
}