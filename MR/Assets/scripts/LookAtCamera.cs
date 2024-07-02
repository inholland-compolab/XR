using UnityEngine;

public class LookAtCamera : MonoBehaviour
{
    private void Update()
    {
        // Get the direction from the object to the camera (local object z axis will be facing away from the camera)
        Vector3 toCamera = transform.position - Camera.main.transform.position;

        // Calculate the rotation to face the camera
        Quaternion lookRotation = Quaternion.LookRotation(toCamera, Vector3.up);

        // Apply the rotation to the object
        transform.rotation = lookRotation;
    }
}