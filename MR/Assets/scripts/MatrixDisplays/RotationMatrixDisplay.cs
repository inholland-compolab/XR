using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RotationMatrixDisplay : MonoBehaviour
{
    public Transform targetObject;

    public Text rotationMatrixText;

    // Update is called once per frame
    void Update()
    {
        Quaternion rotation = targetObject.rotation;

        Vector3 column1 = rotation * Vector3.right;
        Vector3 column2 = rotation * Vector3.up;
        Vector3 column3 = rotation * Vector3.forward;

        string formattedMatrix =
            "Identity Matrix:\n" +
            " [ " + column1.x.ToString("F1") + "  " + column2.x.ToString("F1") + "  " + column3.x.ToString("F1") + " ]\n" +
            " [ " + column1.y.ToString("F1") + "  " + column2.y.ToString("F1") + "  " + column3.y.ToString("F1") + " ]\n" +
            " [ " + column1.z.ToString("F1") + "  " + column2.z.ToString("F1") + "  " + column3.z.ToString("F1") + " ]";

        rotationMatrixText.text = formattedMatrix;
    }
}