using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectAxisConstraint : MonoBehaviour
{
    public Transform yControl;
    public Transform targetObject;

    // Update is called once per frame
    void Update()
    {
        Vector3 controlPosition = yControl.transform.position;
        Vector3 targetPosition = targetObject.transform.position;

        if (targetPosition.y < controlPosition.y)
        {
            targetPosition.y = controlPosition.y;
            transform.position = targetPosition;
        }
    }

}