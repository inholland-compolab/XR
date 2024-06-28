using UnityEngine;
using TMPro;
using System;

[RequireComponent(typeof(TextMeshProUGUI))]
public class GridObjectTracker : MonoBehaviour
{
    public Transform ReferenceObjectTransform;
    public Transform ObjectToTrack;
    public Vector3 textGUIoffset = new Vector3(0f, 1f, 0f);  // Offset to adjust the position

    public Vector3 localGridCoordinates = Vector3.zero;
    private TextMeshProUGUI coordinatesText;

    private void Start()
    {
        coordinatesText = GetComponent<TextMeshProUGUI>();
        if (ReferenceObjectTransform == null || ObjectToTrack == null)
        {
            // Display a warning if the objects are not assigned
            coordinatesText.text = "Please assign objectToTrack and childObject in the inspector.";
        }
    }

    void Update()
    {
        // Get the local coordinates of the child object relative to the object to track
        localGridCoordinates = ReferenceObjectTransform.transform.InverseTransformPoint(ObjectToTrack.position);

        // Round off the coordinates to the nearest whole number
        localGridCoordinates.x = Mathf.Round(localGridCoordinates.x);
        localGridCoordinates.y = Mathf.Round(localGridCoordinates.y);
        localGridCoordinates.z = Mathf.Round(localGridCoordinates.z);

        // Display the rounded coordinates on the TextMeshPro component
        coordinatesText.text = "\n| 1 0 0 " + localGridCoordinates.x + "|" +
                                "\n| 0 1 0 " + localGridCoordinates.z + "|" +
                                "\n| 0 0 1 " + localGridCoordinates.y + "|" +
                                "\n| 0 0 0 1" + "|";

        // Update the TextMeshPro position to follow the target object with the offset
        transform.position = ObjectToTrack.position + textGUIoffset;
    }
}
