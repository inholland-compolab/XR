using UnityEngine;
using System.Collections;

public class MoveObjectScript : MonoBehaviour
{
    public Transform pointA;
    public Transform pointB;
    public float speed = 5f;

    private bool isMoving = false; // Flag to track whether the object is currently moving

    void Start()
    {
        
    }

    public void TriggerMovement()
    {
        if (!isMoving)
        {
            StartCoroutine(MoveObject());
        }
    }

    IEnumerator MoveObject()
    {
        isMoving = true; // Set the flag to true when the movement starts

        float startTime = Time.time;
        float journeyLength = Vector3.Distance(pointA.position, pointB.position);

        while (transform.position != pointB.position)
        {
            float distCovered = (Time.time - startTime) * speed;
            float fractionOfJourney = distCovered / journeyLength;
            transform.position = Vector3.Lerp(pointA.position, pointB.position, fractionOfJourney);

            yield return null;
        }

        isMoving = false; // Set the flag to false when the movement is complete
    }
}
