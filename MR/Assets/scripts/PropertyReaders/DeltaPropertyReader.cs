using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeltaPropertyReader : MonoBehaviour
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

        if (yRotation >= 82 && yRotation <= 98)
        {
            button.SetActive(true);
        }

        else
        {
            button.SetActive(false);
        }
    }
}