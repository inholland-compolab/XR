using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RotationRomeo : MonoBehaviour
{
    public Transform targetObject;
    public Text rotationMatrixText;

    // Update is called once per frame
    void Update()
    {
        //Quaternion rotation = targetObject.rotation;

        //Vector3 column2 = rotation * Vector3.up;
        //Vector3 column3 = rotation * Vector3.forward;

        //string formattedMatrix =
        //    "Current matrix:\n" +
        //    " [ 1,0    0,0    0,0 ]\n" +
        //    " [ 0,0    " + column2.y.ToString("F1") + "    " + column3.y.ToString("F1") + " ]\n" +
        //    " [ 0,0    " + column2.z.ToString("F1") + "    " + column3.z.ToString("F1") + " ]";

        //rotationMatrixText.text = formattedMatrix;

        Quaternion rotation = targetObject.localRotation;

        Vector3 column2 = rotation * Vector3.up;
        Vector3 column3 = rotation * Vector3.forward;

        string formattedMatrix =
            "Current matrix:\n" +
            " [ 1,0    0,0    0,0 ]\n" +
            " [ 0,0    " + column2.y.ToString("F1") + "    " + column3.y.ToString("F1") + " ]\n" +
            " [ 0,0    " + column2.z.ToString("F1") + "    " + column3.z.ToString("F1") + " ]";

        rotationMatrixText.text = formattedMatrix;


    }

    //private static float[][] identityMatrix = {
    //    new []{1.0f, 0.0f, 0.0f},
    //    new []{0.0f, 1.0f, 0.0f},
    //    new []{0.0f, 0.0f, 1.0f}
    //};

    //public static float[][] QuaternionTo3x3(this Quaternion value)
    //{
    //    float[][] matrix3x3 =
    //    {
    //        new float[3],
    //        new float[3],
    //        new float[3],
    //    };

    //    float[][] symetricalMatrix =
    //    {
    //        new float[3] {(-(value.y * value.y) - (value.z * value.z)), value.x * value.y,                                       value.x * value.z},
    //        new float[3] {value.x * value.y, (-(value.x * value.x) - (value.z * value.z)), value.y * value.z},
    //        new float[3] {value.x * value.z, value.y * value.z, (-(value.x * value.x) - (value.y * value.y))}
    //    };

    //    float[][] antiSymetricalMatrix =
    //    {
    //        new []{0.0f, -value.z, value.y},
    //        new []{value.z, 0.0f, -value.x},
    //        new []{-value.y, value.x, 0.0f}
    //    };

    //    for (int i = 0; i < 3; i++)
    //    {
    //        for (int j = 0; j < 3; j++)
    //        {
    //            matrix3x3[j] = identityMatrix[j] + symetricalMatrix[j] + value.w * antiSymetricalMatrix[j];
    //        }
    //    }
    //}
}