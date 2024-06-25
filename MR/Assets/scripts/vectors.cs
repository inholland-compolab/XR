using UnityEngine;

public class ObjectScaler : MonoBehaviour
{
    public Transform targetObjectTransform;
    private Transform originalParent;

    private void Start()
    {
        // Store the original parent
        originalParent = transform.parent;

        // Set the parent to null before scaling
        transform.parent = null;

        // NOTE: functions below should be replaced with Matrix calculation, same as in Maths course.
        // Rotate to face the targeted coordinates
        transform.LookAt(targetObjectTransform);

        // Scale the object
        transform.localScale = new Vector3(
            transform.localScale.x,
            transform.localScale.y,
            Vector3.Distance(transform.position, targetObjectTransform.position)
        );

        // Set the parent back to the original parent
        transform.parent = originalParent;
    }
}
