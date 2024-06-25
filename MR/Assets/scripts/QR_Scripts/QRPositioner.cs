using Microsoft.MixedReality.Toolkit;
using MRTKExtensions.QRCodes;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;

public class QRPositioner : MonoBehaviour
{
    [SerializeField] public QRTrackerController trackerController;
    [SerializeField] public Pose deltaReferencePose = Pose.identity;
    [HideInInspector] public Pose referencePose = Pose.identity;
    [HideInInspector] public Pose latestPose;
    public bool position_relative;

    private void Start()
    {
        StartupVoid();
    }
    public void StartupVoid()
    {
        if (position_relative)
            trackerController.PositionSet += Set_PoseFound_Relative;
        else
            trackerController.PositionSet += PoseFound;
    }
    private Vector3 initialRelativePosition;
    private Quaternion initialRelativeRotation;
    public void Set_Reference_RelativePose()
    {
        referencePose = new Pose(latestPose.position, latestPose.rotation);
        //deltaReferencePose = new Pose(gameObject.transform.position - latestPose.position, transform.rotation * Quaternion.Inverse(latestPose.rotation));
        
        initialRelativePosition = latestPose.InverseTransformPosition(transform.position);
        initialRelativeRotation = Quaternion.Inverse(latestPose.rotation) * transform.rotation;

        deltaReferencePose = new Pose(initialRelativePosition, initialRelativeRotation);

    }
    private void Set_PoseFound_Relative(object sender, Pose pose)
    {
        latestPose = pose;
        Set_Reference_RelativePose();
        trackerController.PositionSet -= Set_PoseFound_Relative;
        trackerController.PositionSet += PoseFound_Relative;
    }
    private void PoseFound_Relative(object sender, Pose pose)
    {
        latestPose = pose;
        gameObject.transform.SetPositionAndRotation(
            deltaReferencePose.position.GetRotatedPointAroundPivot(Vector3.zero, pose.rotation * Quaternion.Inverse(referencePose.rotation)) + pose.position,
            pose.rotation * deltaReferencePose.rotation
            );
    }
    private void PoseFound(object sender, Pose pose)
    {
        latestPose = pose;
        transform.SetPositionAndRotation(pose.position, pose.rotation);
        //gameObject.SetActive(true);
       /* gameObject.SetHierarchyActive(true);*/
    }
    public void ResetOrigin()
    {
        if (deltaReferencePose == Pose.identity)
            return;
        deltaReferencePose = Pose.identity;
        referencePose = Pose.identity;
        trackerController.PositionSet -= Set_PoseFound_Relative;
        trackerController.PositionSet -= PoseFound_Relative;
        trackerController.PositionSet -= PoseFound;
        Start();
    }
}
