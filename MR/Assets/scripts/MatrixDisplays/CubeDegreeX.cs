using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CubeDegreeX : MonoBehaviour
{
    public Transform targetObject;
    public Text matrixDegreeX;

    // Update is called once per frame
    void Update()
    {
        Quaternion rotation = targetObject.localRotation;

        Vector3 eulerRotation = QuaternionToEulerAngles(rotation);

        float xRotation = Mathf.Round(QuaternionToEulerAngles(rotation).x);

        string matrix = "";

        if (xRotation == 0)
        {
            matrix =
            "X-axis Rotation matrix:\n" +
            " [ 1,0       0,0       0.0 ]\n" +
            " [ 0,0  cos(θ)  -sin(θ) ]\n" +
            " [ 0,0   sin(θ)  cos(θ) ]";
        }

        else
        {
            matrix =
            "X-axis Rotation matrix:\n" +
            " [ 1,0       0,0       0.0 ]\n" +
            " [ 0,0  cos(" + xRotation + ") -sin(" + xRotation + ") ]\n" +
            " [ 0,0  sin(" + xRotation + ")  cos(" + xRotation + ") ]";
        }

        matrixDegreeX.text = matrix;
    }

    private Vector3 QuaternionToEulerAngles(Quaternion q)
    {
        float pitch = Mathf.Atan2(2 * (q.y * q.z + q.w * q.x), q.w * q.w - q.x * q.x - q.y * q.y + q.z * q.z) * Mathf.Rad2Deg;
        float yaw = Mathf.Asin(-2 * (q.x * q.z - q.w * q.y)) * Mathf.Rad2Deg;
        float roll = Mathf.Atan2(2 * (q.x * q.y + q.w * q.z), q.w * q.w + q.x * q.x - q.y * q.y - q.z * q.z) * Mathf.Rad2Deg;

        return new Vector3(pitch, yaw, roll);
    }
}