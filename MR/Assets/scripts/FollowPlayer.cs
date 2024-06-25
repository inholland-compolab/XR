using UnityEngine;

public class FaceMainCamera : MonoBehaviour
{
    private Camera mainCamera;
    private bool isScriptEnabled = true;
    private Quaternion initialRotation;

    void Start()
    {
        mainCamera = Camera.main;

        if (mainCamera == null)
        {
            Debug.LogError("Main camera not found in the scene. Make sure you have a main camera.");
        }

        // Store the initial rotation
        initialRotation = transform.rotation;
    }

    void Update()
    {
        if (isScriptEnabled && mainCamera != null)
        {
            // Face the main camera without changing scale
            Vector3 lookAtPos = new Vector3(mainCamera.transform.position.x, transform.position.y, mainCamera.transform.position.z);

            // Calculate the rotation to face the main camera
            transform.LookAt(lookAtPos);
        }
    }

    // Method to toggle the script on/off
    public void ToggleScript()
    {
        isScriptEnabled = !isScriptEnabled;

        if (!isScriptEnabled)
        {
            // Reset to initial rotation when the script is disabled
            transform.rotation = initialRotation;

            // Add any additional actions when the script is disabled
        }
    }
}





