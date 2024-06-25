using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Part4PropertyReader : MonoBehaviour
{
    public float xRotation;
    public float yRotation;
    public float zRotation;

    public GameObject button;

    // Start is called before the first frame update
    void Start()
    {
        button.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 currentRotation = transform.rotation.eulerAngles;

        xRotation = currentRotation.x;
        yRotation = currentRotation.y;
        zRotation = currentRotation.z;

        if ((xRotation >= 5f && xRotation <= 15f) &&
            (zRotation >= 265f && zRotation <= 275f))
        {
            Debug.Log("Correct rotation");
            button.SetActive(true);
        }

        else if ((xRotation >= 345f && xRotation <= 355f) &&
            (zRotation >= 85f && zRotation <= 95f))
        {
            Debug.Log("Secondary Correct rotation");
            button.SetActive(true);
        }

        else
        {
            button.SetActive(false);
        }
    }
}