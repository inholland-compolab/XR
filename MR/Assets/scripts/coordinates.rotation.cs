using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ObjectRotationTracker : MonoBehaviour
{
    public TextMeshProUGUI rotationText;

    private Quaternion lastRotation;

    void Start()
    {
        lastRotation = transform.rotation;
    }

    void Update()
    {
        if (transform.rotation != lastRotation)
        {
            lastRotation = transform.rotation;

            // Extract the Euler angles for the rotation
            Vector3 eulerAngles = lastRotation.eulerAngles;

            // Subtract 180 degrees from the Y-axis rotation
            eulerAngles.y -= 180;

            // Ensure Y-axis rotation is positive for counterclockwise rotation
            eulerAngles.y = Mathf.Abs(eulerAngles.y);

            // Round the rotation angles to whole numbers
            
          eulerAngles.z = Mathf.Round(eulerAngles.z);

            // Format the rotation angles as a string
            string rotationInfo = "?: " + eulerAngles.z;

            rotationText.text = rotationInfo;
        }
    }
}
