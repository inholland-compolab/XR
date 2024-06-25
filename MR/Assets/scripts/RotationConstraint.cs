using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Part2RotationConstraint : MonoBehaviour
{
    public float minXRotation;
    public float maxXRotation;
    public float minZRotation;
    public float maxZRotation;

    // Update is called once per frame
    void Update()
    {
        Vector3 currentRotation = transform.localEulerAngles;

        if (currentRotation.x > 180)
        {
            currentRotation.x -= 360;
        }

        if (currentRotation.z > 180)
        {
            currentRotation.z -= 360;
        }

        currentRotation.x = Mathf.Clamp(currentRotation.x, minXRotation, maxXRotation);
        currentRotation.z = Mathf.Clamp(currentRotation.z, minZRotation, maxZRotation);

        transform.localRotation = Quaternion.Euler(currentRotation);
    }
}
