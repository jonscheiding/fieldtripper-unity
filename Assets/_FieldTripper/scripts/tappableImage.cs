using Prime31.MessageKit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets._FieldTripper.scripts
{
    public class TappableImage : MonoBehaviour
    {
        [SerializeField]
        protected ImageTracker MyTrackedImage;

		private void Start()
		{
			if (MyTrackedImage == null)
			{
				Logging.LogMessage(String.Format("MyTrackedImage null on {0}", name), "tappablestart");
			}
			else
			{
				Logging.LogMessage(String.Format("MyTrackedImage not null on {0}", name), "tappablestart");
			}
		}

		private void Update()
        {
            foreach (Touch touch in Input.touches)
            {
                if (touch.phase == TouchPhase.Ended)
                {
                    Ray ray = Camera.main.ScreenPointToRay(touch.position);
                    RaycastHit hit;
                    if (Physics.Raycast(ray, out hit) == true)
                    {
						if (MyTrackedImage == null)
						{
							Logging.LogMessage(String.Format("imageTracker null on {0}", name), "MyTrackedImage");
						}
						else
						{
							Logging.LogMessage(String.Format("imageTracker not null on {0}", name), "MyTrackedImage");
							OnTapped();
						}

						MessageKit<string>.post((int)Messages.tapped, MyTrackedImage.Id);
					}
				}
            }
        }

		protected virtual void OnTapped()
		{
			Logging.LogMessage("OnTapped()");
		}
	}
}
