using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CubeDegreeY : MonoBehaviour
{
    public Transform targetObject;
    public Text matrixDegreeY;

    // Update is called once per frame
    void Update()
    {
        Quaternion rotation = targetObject.localRotation;

        Vector3 eulerRotation = QuaternionToEulerAngles(rotation);

        float yRotation = Mathf.Round(QuaternionToEulerAngles(rotation).y);

        string matrix = "";

        if (yRotation == 0)
        {
            matrix =
            "Y-axis Rotation matrix:\n" +
            " [ cos(θ)   0,0  sin(θ) ]\n" +
            " [     0,0    0,0      0,0 ]\n" +
            " [ -sin(θ)   0,0 cos(θ) ]";
        }

        else
        {
            matrix =
            "X-axis Rotation matrix:\n" +
            " [ cos(" + yRotation + ")   0,0  sin(" + yRotation + ") ]\n" +
            " [     0,0    0,0      0,0 ]\n" +
            " [ -sin(" + yRotation + ")   0,0 cos(" + yRotation + ") ]";
        }

        matrixDegreeY.text = matrix;
    }

    private Vector3 QuaternionToEulerAngles(Quaternion q)
    {
        float pitch = Mathf.Atan2(2 * (q.y * q.z + q.w * q.x), q.w * q.w - q.x * q.x - q.y * q.y + q.z * q.z) * Mathf.Rad2Deg;
        float yaw = Mathf.Asin(-2 * (q.x * q.z - q.w * q.y)) * Mathf.Rad2Deg;
        float roll = Mathf.Atan2(2 * (q.x * q.y + q.w * q.z), q.w * q.w + q.x * q.x - q.y * q.y - q.z * q.z) * Mathf.Rad2Deg;

        return new Vector3(pitch, yaw, roll);
    }
}