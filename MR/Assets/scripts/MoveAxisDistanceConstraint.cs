using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveAxisDistanceConstraint : MonoBehaviour
{
    public Vector3 maxDistance;

    private Vector3 initialPosition;
    private Vector3 maxPosition; // Set this to your desired maximum position
    private Vector3 minPosition; // Set this to your desired minimum position

    void Start()
    {
        initialPosition = transform.localPosition;
        // Example: Set max and min positions relative to initial position
        maxPosition = initialPosition + maxDistance;
        minPosition = initialPosition - maxDistance;
    }

    void Update()
    {
        // Example: Get input (e.g., hand movement)
        //Vector3 inputMovement = new Vector3(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"), Input.GetAxis("Depth"));
        Vector3 newPosition = transform.localPosition;

        //// Calculate new position
        //Vector3 newPosition = initialPosition + inputMovement;

        // Clamp position within limits
        newPosition.x = Mathf.Clamp(newPosition.x, minPosition.x, maxPosition.x);
        newPosition.y = Mathf.Clamp(newPosition.y, minPosition.y, maxPosition.y);
        newPosition.z = Mathf.Clamp(newPosition.z, minPosition.z, maxPosition.z);

        // Apply the new position
        transform.localPosition = newPosition;
    }
}
