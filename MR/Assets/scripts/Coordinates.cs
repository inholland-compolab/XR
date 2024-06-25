using UnityEngine;
using TMPro;

public class ObjectTracker : MonoBehaviour
{
    public Transform objectToTrack;
    public Transform childObject;

    public TextMeshProUGUI coordinatesText;

    void Update()
    {
        // Check if the object to track and child object are assigned
        if (objectToTrack != null && childObject != null)
        {
            // Get the local coordinates of the child object relative to the object to track
            Vector3 localCoordinates = objectToTrack.transform.InverseTransformPoint(childObject.position);

            // Round off the coordinates to the nearest whole number
            localCoordinates.x = Mathf.Round(localCoordinates.x);
            localCoordinates.y = Mathf.Round(localCoordinates.y);
            localCoordinates.z = Mathf.Round(localCoordinates.z);

            // Display the rounded coordinates on the TextMeshPro component
            coordinatesText.text = "\n| 1 0 0 " + localCoordinates.x + "|" +
                                   "\n| 0 1 0 " + localCoordinates.z + "|" +
                                   "\n| 0 0 1 " + localCoordinates.y + "|" +
                                   "\n| 0 0 0 1" + "|";
        }
        else
        {
            // Display a warning if the objects are not assigned
            coordinatesText.text = "Please assign objectToTrack and childObject in the inspector.";
        }
    }
}
