using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeltaPropertyReader : MonoBehaviour
{
    //private float xRotation;
    public float yRotation;
    //private float zRotation;

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

        //xRotation = currentRotation.x;
        yRotation = currentRotation.y;
        //zRotation = currentRotation.z;

        if (yRotation <= 276 && yRotation >= 264)  // 360 - 90 degrees = 270
        {
            button.SetActive(true);
        }

        else
        {
            button.SetActive(false);
        }
    }
}