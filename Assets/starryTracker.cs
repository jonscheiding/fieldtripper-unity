using Assets._FieldTripper.scripts;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.iOS;

namespace Assets._FieldTripper
{
    public class starryTracker : MonoBehaviour
    {
        [SerializeField]
        private ARReferenceImage referenceImage;

        [SerializeField]
        private GameObject anchorObject;

        private void Start()
        {
            Logging.LogMessage("starryTracker Start()");
            if (anchorObject == null)
            {
                Logging.LogError("Anchor object cannot be null.", true);
            }

            anchorObject.SetActive(false);
            UnityARSessionNativeInterface.ARImageAnchorAddedEvent += ImageAnchorAddedEvent;
            UnityARSessionNativeInterface.ARImageAnchorUpdatedEvent += ImageAnchorUpdatedEvent;
            UnityARSessionNativeInterface.ARImageAnchorRemovedEvent += ImageAnchorRemovedEvent;
            Logging.LogMessage("starryTracker Start() end");
           
        }

        private void ImageAnchorAddedEvent(ARImageAnchor anchorData)
        {
            Logging.LogMessage("image anchor added");
            anchorObject.SetActive(true);
            updateAnchorObject(anchorData);
        }

        private void ImageAnchorUpdatedEvent(ARImageAnchor anchorData)
        {
            Logging.LogMessage("image anchor updated");
            updateAnchorObject(anchorData);
        }

        private void updateAnchorObject(ARImageAnchor anchorData)
        {
            Logging.LogMessage("updateAnchorObject()");
            anchorObject.transform.position = UnityARMatrixOps.GetPosition(anchorData.transform);
            anchorObject.transform.rotation = UnityARMatrixOps.GetRotation(anchorData.transform);
            Vector3 newPosition = anchorObject.transform.position;
            Logging.LogMessage(string.Format("Anchor moved to ({0}, {1}, {2})", newPosition.x.ToString("n2"), newPosition.y.ToString("n2"), newPosition.z.ToString("n2")));
        }

        private void ImageAnchorRemovedEvent(ARImageAnchor anchorData)
        {
            Logging.LogMessage("image anchor removed");
            anchorObject.SetActive(false);
        }

        private void Update()
        {

        }

        private void OnDestroy()
        {
            UnityARSessionNativeInterface.ARImageAnchorAddedEvent -= ImageAnchorAddedEvent;
            UnityARSessionNativeInterface.ARImageAnchorUpdatedEvent -= ImageAnchorUpdatedEvent;
            UnityARSessionNativeInterface.ARImageAnchorRemovedEvent -= ImageAnchorRemovedEvent;
        }
    }
}