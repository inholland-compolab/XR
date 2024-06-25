using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotationClamp : MonoBehaviour
{
    public float minXRotation = -180f;
    public float maxXRotation = 180f;
    public float minYRotation = -10f;
    public float maxYRotation = 10f;
    public float minZRotation = -10f;
    public float maxZRotation = 10f;

    // Update is called once per frame
    private void Update()
    {
        Vector3 currentRotation = transform.localEulerAngles;

        if (currentRotation.x > 180) currentRotation.x -= 360;
        if (currentRotation.y > 180) currentRotation.y -= 360;
        if (currentRotation.z > 180) currentRotation.z -= 360;

        currentRotation.x = Mathf.Clamp(currentRotation.x, minXRotation, maxXRotation);
        currentRotation.y = Mathf.Clamp(currentRotation.y, minYRotation, maxYRotation);
        currentRotation.z = Mathf.Clamp(currentRotation.z, minZRotation, maxZRotation);

        transform.localRotation = Quaternion.Euler(currentRotation);
    }
}
