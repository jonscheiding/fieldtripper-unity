using Assets._FieldTripper.scripts;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.iOS;

namespace Assets._FieldTripper
{
    public class ImageTracker : MonoBehaviour
    {
        [SerializeField]
        private string id;

        [SerializeField]
        private ARReferenceImage referenceImage;

		[SerializeField]
		protected Texture originalTexture;

        [SerializeField]
        protected GameObject anchorObject;

        private Vector3 offset;

        public string Id
        {
            get { return id; }
        }

		public ARReferenceImage ReferenceImage
		{
			get { return ReferenceImage; }
		}

		public Material ReferenceMaterial
		{
			get { return anchorObject.GetComponent<Renderer>().material; }
		}

		private void Start()
        {
            if (anchorObject == null)
            {
                Logging.LogError("Anchor object cannot be null.", true);
            }

            anchorObject.SetActive(false);
            UnityARSessionNativeInterface.ARImageAnchorAddedEvent += ImageAnchorAddedEvent;
            UnityARSessionNativeInterface.ARImageAnchorUpdatedEvent += ImageAnchorUpdatedEvent;
            UnityARSessionNativeInterface.ARImageAnchorRemovedEvent += ImageAnchorRemovedEvent;
            UnityARSessionNativeInterface.ARSessionTrackingChangedEvent += TrackingChangedEvent;
        }

        private void TrackingChangedEvent(UnityARCamera camera)
        {
            Logging.LogMessage(string.Format("Tracking state: {0}", camera.trackingState));
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
            anchorObject.transform.position = UnityARMatrixOps.GetPosition(anchorData.transform) + offset;
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
            UnityARSessionNativeInterface.ARSessionTrackingChangedEvent -= TrackingChangedEvent;
        }
    }
}