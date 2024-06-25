using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnabledOrDisabled : MonoBehaviour
{
    public GameObject pic;

    [SerializeField]
    private GameObject TextToAppear; // The object that should appear when object1 is rotated.

    [SerializeField]
    private float targetAngle = 22.0f; // The target rotation angle.

    private bool Text2Appeared = false;

    // Start is called before the first frame update
    void Start()
    {
        // Set the canvas to be inactive (hidden) at the start of the game
        pic.SetActive(false);
    }

    void Update()
    {
        // Check if the current GameObject's Z rotation is within the specified range of degrees (inclusive).
        float zRotation = transform.eulerAngles.z;

        if (Mathf.Abs(zRotation - targetAngle) <= 3.0f && !Text2Appeared)
        {
            pic.SetActive(false); // Hide pic if it's shown.
            TextToAppear.SetActive(true); // Show object2.
            Text2Appeared = true; // Set the flag to true to prevent repeated activation.
        }
        else if (Mathf.Abs(zRotation - targetAngle) > 3.0f)
        {
            pic.SetActive(false); // Hide pic if it's shown when the Z rotation is outside the allowed range.
            TextToAppear.SetActive(false); // Hide object2 if the Z rotation is outside the allowed range.
            Text2Appeared = false; // Reset the flag when Z rotation is out of the allowed range.
        }
    }

    public void Trigger()
    {
        // Toggle the visibility of the canvas
        if (!pic.activeSelf)
        {
            pic.SetActive(true); // Make it active (visible)
        }
        else
        {
            pic.SetActive(false); // Make it inactive (hidden)
        }
    }
}
