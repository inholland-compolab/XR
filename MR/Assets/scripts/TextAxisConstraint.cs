using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextAxisConstraint : MonoBehaviour
{
    public Transform yControl;
    public Transform text;

    // Update is called once per frame
    void Update()
    {
        Vector3 controlPosition = yControl.transform.position;
        Vector3 textPosition = text.transform.position;

        if (textPosition.y < controlPosition.y)
        {
            textPosition.y = controlPosition.y;
            transform.position = textPosition;
        }
    }

}