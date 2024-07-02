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
        Quaternion rotation = targetObject.rotation;

        Vector3 column2 = rotation * Vector3.up;
        Vector3 column3 = rotation * Vector3.forward;

        string formattedMatrix =
            "Current matrix:\n" +
            " [ 1,0    0,0    0,0 ]\n" +
            " [ 0,0    " + column2.y.ToString("F1") + "    " + column3.y.ToString("F1") + " ]\n" +
            " [ 0,0    " + column2.z.ToString("F1") + "    " + column3.z.ToString("F1") + " ]";

        rotationMatrixText.text = formattedMatrix;
    }
}