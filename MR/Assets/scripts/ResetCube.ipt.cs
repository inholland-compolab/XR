using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetCube : MonoBehaviour
{
    [SerializeField] private bool resetOnEnable = false;
    private void OnEnable()
    {
        if (resetOnEnable) 
            ResetObject();
    }
    public void ResetObject()
    {
        transform.localRotation = Quaternion.identity;
    }
}