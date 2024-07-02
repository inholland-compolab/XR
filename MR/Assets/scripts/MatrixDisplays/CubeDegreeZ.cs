using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CubeDegreeZ : MonoBehaviour
{
    public Transform targetObject;
    public Text matrixDegreeZ;

    // Update is called once per frame
    void Update()
    {
        Quaternion rotation = targetObject.localRotation;

        Vector3 eulerRotation = QuaternionToEulerAngles(rotation);

        float zRotation = Mathf.Round(QuaternionToEulerAngles(rotation).z);

        string matrix = "";

        if (zRotation == 0)
        {
            matrix =
            "Z-axis Rotation matrix:\n" +
            " [ cos(θ)  -sin(θ)   0.0 ]\n" +
            " [  sin(θ)  cos(θ)   0,0 ]\n" +
            " [      0,0      0,0    0,0 ]";
        }

        else
        {
            matrix =
            "Z-axis Rotation matrix:\n" +
            " [ cos(" + zRotation + ")  -sin(" + zRotation + ")   0.0 ]\n" +
            " [ sin(" + zRotation + ")   cos(" + zRotation + ")   0,0 ]\n" +
            " [      0,0      0,0    0,0 ]";
        }

        matrixDegreeZ.text = matrix;
    }

    private Vector3 QuaternionToEulerAngles(Quaternion q)
    {
        float pitch = Mathf.Atan2(2 * (q.y * q.z + q.w * q.x), q.w * q.w - q.x * q.x - q.y * q.y + q.z * q.z) * Mathf.Rad2Deg;
        float yaw = Mathf.Asin(-2 * (q.x * q.z - q.w * q.y)) * Mathf.Rad2Deg;
        float roll = Mathf.Atan2(2 * (q.x * q.y + q.w * q.z), q.w * q.w + q.x * q.x - q.y * q.y - q.z * q.z) * Mathf.Rad2Deg;

        return new Vector3(pitch, yaw, roll);
    }
}