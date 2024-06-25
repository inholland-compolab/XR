using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Newtonsoft.Json;
using System.Text;
using System.IO;

public class QR_Manager : MonoBehaviour
{
    [System.Serializable]
    private class RelativeTransform
    {
        public RelativeTransform() { }
        public RelativeTransform(Transform transform)
        {
            AssignLocalTransform(transform);
        }
        public RelativeTransform(Pose relativePose, Quaternion referenceRotation, Vector3 currentScale)
        {
            AssignLocalTransform(relativePose, referenceRotation, currentScale);
        }

        public Vector3 localPosition;
        public Quaternion localRotation;
        public Vector3 localScale;
        public Quaternion referenceRotation;

        public void AssignLocalTransform(Transform sourceTransform)
        {
            localPosition = sourceTransform.localPosition + Vector3.zero;
            localRotation = sourceTransform.localRotation * Quaternion.identity;
            localScale = sourceTransform.localScale + Vector3.zero;
        }
        public void AssignLocalTransform(Pose sourcePose, Quaternion referenceRotation, Vector3 sourceScale)
        {
            localPosition = sourcePose.position + Vector3.zero;
            localRotation = sourcePose.rotation * Quaternion.identity;
            localScale = sourceScale + Vector3.zero;

            this.referenceRotation = referenceRotation;
        }
        public void TransferRelativeTransform(Transform destTransform, Pose currentPose, bool localIsWorld = false)
        {
            //destTransform.position = localPosition.GetRotatedPointAroundPivot(Quaternion.Euler(0, 180, 0) * (currentPose.rotation * this.referenceRotation)) + currentPose.position;
            //destTransform.rotation = localRotation * currentPose.rotation;

            GameObject qrCodeTempObj = new GameObject();
            qrCodeTempObj.transform.SetPositionAndRotation(currentPose.position, currentPose.rotation);
            destTransform.position = qrCodeTempObj.transform.TransformPoint(localPosition);
            destTransform.rotation = qrCodeTempObj.transform.rotation * localRotation;
            Destroy(qrCodeTempObj);
        }
    }

    public virtual void SaveToDisk_RelativePose(bool includeInactive=false)
    {
        QRPositioner[] QRPositionerInScene = GameObject.FindObjectsOfType<QRPositioner>(includeInactive);
        foreach(QRPositioner qrPositioner in QRPositionerInScene)
        {
            if (qrPositioner.deltaReferencePose == Pose.identity)
                continue;
            qrPositioner.Set_Reference_RelativePose();

            RelativeTransform relativeTransform = new RelativeTransform(qrPositioner.deltaReferencePose, qrPositioner.referencePose.rotation, qrPositioner.transform.localScale);
            string jsonString_Transform = JsonConvert.SerializeObject(relativeTransform, Formatting.Indented,
                new JsonSerializerSettings { ReferenceLoopHandling = ReferenceLoopHandling.Ignore });

            string QR_RelativeWorldOrigin_file = Application.persistentDataPath + "/" + "QR_RelativeWorldOrigin_" + qrPositioner.gameObject.name + ".json";
            Debug.Log(QR_RelativeWorldOrigin_file);
            File.WriteAllText(QR_RelativeWorldOrigin_file, jsonString_Transform);
        }
    }
    public virtual void LoadFromDisk_RelativePose(bool localIsWorld = false)
    {
        QRPositioner[] QRPositionerInScene = GameObject.FindObjectsOfType<QRPositioner>(/*includeInactive: true*/);
        foreach (QRPositioner qrPositioner in QRPositionerInScene)
        {
            if (qrPositioner.deltaReferencePose == Pose.identity)
                continue;

            string QR_RelativeWorldOrigin_file = Application.persistentDataPath + "/" + "QR_RelativeWorldOrigin_" + qrPositioner.gameObject.name + ".json";
            string jsonString_Transform = File.ReadAllText(QR_RelativeWorldOrigin_file);
            RelativeTransform jsonTransform = JsonConvert.DeserializeObject<RelativeTransform>(jsonString_Transform)!;
            jsonTransform.TransferRelativeTransform(qrPositioner.gameObject.transform, qrPositioner.latestPose);
        }
    }
    public virtual void ResetOrigins()
    {
        QRPositioner[] QRPositionerInScene = GameObject.FindObjectsOfType<QRPositioner>(/*includeInactive: true*/);
        foreach (QRPositioner qrPositioner in QRPositionerInScene)
        {
            qrPositioner.ResetOrigin();
        }
    }
}
