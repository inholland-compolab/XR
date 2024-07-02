using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetRobotArm : MonoBehaviour
{
    public GameObject RobotObject;
    private List<Transform> cylinderTransforms = new List<Transform>();

    void OnEnable()
    {
        if (RobotObject == null) {
            Debug.LogWarning("RobotObject not assigned! Setting local object as robot object...");
            RobotObject = gameObject;
        }
        // Recursively find all child transforms
        ResetCylinderRotations();
    }

    private void GetAllChildTransforms(Transform parent)
    {
        foreach (Transform child in parent)
        {
            if (child.name.Contains("Cylinder"))
            {
                cylinderTransforms.Add(child);
            }

            // Recurse into sub-children
            GetAllChildTransforms(child);
        }
    }
    public void ResetCylinderRotations()
    {
        Debug.Log("Resetting Robot Arm");
        if (cylinderTransforms.Count == 0)
            GetAllChildTransforms(RobotObject.transform);
        foreach (Transform cylinderTransform in cylinderTransforms)
        {
            cylinderTransform.localRotation = Quaternion.identity;
        }
    }
}
