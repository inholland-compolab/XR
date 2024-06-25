using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Part3PropertyReader : MonoBehaviour
{
    public float xRotation;
    public float yRotation;
    public float zRotation;

    public GameObject continueButton;

    // Start is called before the first frame update
    void Start()
    {
        continueButton.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 currentRotation = transform.rotation.eulerAngles;

        xRotation = currentRotation.x;
        yRotation = currentRotation.y;
        zRotation = currentRotation.z;

        if (((xRotation == 0f) || (xRotation >= 0.001f && xRotation <= 4f) || (xRotation >= 356f && xRotation <= 360f)) &&
            ((zRotation == 0f) || (zRotation >= 0.001f && zRotation <= 4f) || (zRotation >= 356f && zRotation <= 360f)))
        {
            Debug.Log("Correct rotation");
            continueButton.SetActive(true);
        }

        else if (((xRotation == 0f) || (xRotation >= 0.001f && xRotation <= 4f) || (xRotation >= 356f && xRotation <= 360f)) &&
                 (zRotation >= 176f && zRotation <= 184f))
        {
            Debug.Log("Secondary Correct rotation");
            continueButton.SetActive(true);
        }

        else
        {
            continueButton.SetActive(false);
        }
    }
}