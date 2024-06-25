using System;
using Microsoft.MixedReality.Toolkit;
using UnityEngine;

namespace MRTKExtensions.QRCodes
{
    public class QRTrackerController : MonoBehaviour
    {
        [SerializeField]
        private SpatialGraphCoordinateSystemSetter spatialGraphCoordinateSystemSetter;

        [SerializeField]
        private string locationQrValue = string.Empty;

        private Transform markerHolder;
        private AudioSource audioSource;
        private GameObject markerDisplay;
        private QRInfo lastMessage;
   
        public bool IsTrackingActive { get; private set; } = true;
        public bool IsContinuesTracking { get; private set; } = false;
        public bool isContinuesTracking = false;
        public void SetContinuesTracking(Microsoft.MixedReality.Toolkit.UI.Interactable interactable_sender) { IsContinuesTracking = interactable_sender.IsToggled; }

        private IQRCodeTrackingService qrCodeTrackingService;

        private IQRCodeTrackingService QRCodeTrackingService
        {
            get
            {
                while (!MixedRealityToolkit.IsInitialized && Time.time < 5) ;
                return qrCodeTrackingService ??
                       (qrCodeTrackingService = MixedRealityToolkit.Instance.GetService<IQRCodeTrackingService>());
            }
        }

        private void Start()
        {
            IsContinuesTracking = isContinuesTracking;
            if (!QRCodeTrackingService.IsSupported)
            {
                return;
            }

            markerHolder = spatialGraphCoordinateSystemSetter.gameObject.transform;
            markerDisplay = markerHolder.GetChild(0).gameObject;
            markerDisplay.SetActive(false);

            audioSource = markerHolder.gameObject.GetComponent<AudioSource>();

            QRCodeTrackingService.QRCodeFound += ProcessTrackingFound;
            spatialGraphCoordinateSystemSetter.PositionAcquired += SetPosition;
            spatialGraphCoordinateSystemSetter.PositionAcquisitionFailed +=
                (s, e) => ResetTracking();


            if (QRCodeTrackingService.IsInitialized)
            {
                StartTracking();
            }
            else
            {
                QRCodeTrackingService.Initialized += QRCodeTrackingService_Initialized;
            }
        }

        private void QRCodeTrackingService_Initialized(object sender, EventArgs e)
        {
            StartTracking();
        }

        public void StartTracking()
        {
            //if (!QRCodeTrackingService.IsTracking)
            QRCodeTrackingService.Enable();
        }

        public void StopTracking()
        {
            if (QRCodeTrackingService.IsTracking)
                QRCodeTrackingService.Disable();
        }

        public void ResetTracking()
        {
            if (QRCodeTrackingService.IsInitialized)
            {
                if (!QRCodeTrackingService.IsTracking)
                    QRCodeTrackingService.Enable();
                markerDisplay.SetActive(false);
                IsTrackingActive = true;
            }
        }

        private void ProcessTrackingFound(object sender, QRInfo msg)
        {
            if (msg == null || !IsTrackingActive )
            {
                return;
            }

            lastMessage = msg;

            if (msg.Data == locationQrValue /*&& Math.Abs((DateTimeOffset.UtcNow - msg.LastDetectedTime.UtcDateTime).TotalMilliseconds) < 100*/)
            {
                spatialGraphCoordinateSystemSetter.SetLocationIdSize(msg.SpatialGraphNodeId,
                    msg.PhysicalSideLength);
            }
        }

        private void SetPosition(object sender, Pose pose)
        {
            IsTrackingActive = IsContinuesTracking;
            markerHolder.localScale = Vector3.one * lastMessage.PhysicalSideLength;
            markerDisplay.SetActive(true);
            PositionSet?.Invoke(this, pose);
            //audioSource.Play();
        }

        [Header("Development test pose")]
        [Tooltip("Pose to simulate retrieved QR pose, utilized by TestSetPosition()")]
        [SerializeField] public Pose testPose = new Pose(Vector3.one, Quaternion.identity);
        public void TestSetPosition(Transform givenTransform=null)
        {
            //Pose testPose = new Pose(Vector3.one, Quaternion.identity);
            PositionSet?.Invoke(this, (givenTransform==null? testPose : new Pose(givenTransform.position, givenTransform.rotation)));
        }

        public EventHandler<Pose> PositionSet;
    }
}