using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetScript : MonoBehaviour
{
    public Transform resetLocation;

    public void ResetObject()
    {
        transform.position = resetLocation.position;
        transform.rotation = Quaternion.Euler(10, 0, 90);
    }
}