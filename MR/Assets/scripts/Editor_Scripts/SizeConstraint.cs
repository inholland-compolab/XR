#if UNITY_EDITOR
using UnityEditor;
#endif
using UnityEngine;

[ExecuteAlways]
public class SizeConstraint : MonoBehaviour
{
    public bool IsActive = false;
    public Transform constaintSourceObject;
    public float scaleFactor = 1.0f;

    private void UpdateScale()
    {
        if (constaintSourceObject != null)
        {
            // Calculate the distance between this object and the source
            float distance = Vector3.Distance(transform.position, constaintSourceObject.position);

            // Calculate the scale based on the distance (adjust this as needed)
            float newScale = distance * scaleFactor;

            // Set the scale only on the z-axis (assuming z-axis scaling only)
            Vector3 newScaleVector = new Vector3(transform.localScale.x, transform.localScale.y, newScale);
            transform.localScale = newScaleVector;
        }
    }

#if UNITY_EDITOR
    private void OnEnable()
    {
        EditorApplication.update += EditorUpdate;
    }

    private void OnDisable()
    {
        EditorApplication.update -= EditorUpdate;
    }

    private void EditorUpdate()
    {
        // Check if the constraint is active in the scene view
        if (IsActive && !Application.isPlaying)
        {
            UpdateScale();
        }
    }
#endif

    private void Update()
    {
        // Check if the constraint is active during runtime
        if (IsActive && Application.isPlaying)
        {
            UpdateScale();
        }
    }
}
