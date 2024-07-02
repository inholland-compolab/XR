using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Part3PropertyReader : MonoBehaviour
{
    private float xRotation;
    private float yRotation;
    private float zRotation;

    public GameObject continueButton;
    public UnityEvent onCorrect = new UnityEvent();
    public UnityEvent onIncorrect = new UnityEvent();

    // Start is called before the first frame update
    void Start()
    {
        continueButton.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 currentRotation = transform.localRotation.eulerAngles;

        xRotation = currentRotation.x;
        yRotation = currentRotation.y;
        zRotation = currentRotation.z;

        if (((xRotation == 0f) || (xRotation >= 0.001f && xRotation <= 8f) || (xRotation >= 352f && xRotation <= 360f)) &&
            ((zRotation == 0f) || (zRotation >= 0.001f && zRotation <= 8f) || (zRotation >= 352f && zRotation <= 360f)))
        {
            Debug.Log("Correct rotation");
            continueButton.SetActive(true);
            onCorrect.Invoke();
        }

        else if (((xRotation == 0f) || (xRotation >= 0.001f && xRotation <= 8f) || (xRotation >= 352f && xRotation <= 360f)) &&
                 (zRotation >= 172f && zRotation <= 188f))
        {
            Debug.Log("Secondary Correct rotation");
            continueButton.SetActive(true);
            onCorrect.Invoke();
        }

        else
        {
            continueButton.SetActive(false);
            onIncorrect.Invoke();
        }
    }
}