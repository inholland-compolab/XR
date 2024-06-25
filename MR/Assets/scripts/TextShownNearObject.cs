using UnityEngine;
using TMPro;

public class FollowObject : MonoBehaviour
{
    public Transform targetObject;  // The object to follow
    public Vector3 offset = new Vector3(0f, 1f, 0f);  // Offset to adjust the position

    private TextMeshPro textMeshPro;

    void Start()
    {
        // Assuming your TextMeshPro component is attached to the same GameObject as this script
        textMeshPro = GetComponent<TextMeshPro>();

        if (targetObject == null)
        {
            Debug.LogError("Target object not assigned in FollowObject script.");
        }
    }

    void Update()
    {
        if (targetObject != null)
        {
            // Update the TextMeshPro position to follow the target object with the offset
            transform.position = targetObject.position + offset;
        }
    }
}

