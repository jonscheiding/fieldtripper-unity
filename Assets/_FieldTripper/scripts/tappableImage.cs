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
        protected ImageTracker imageTracker;

		private void Start()
		{
			if (imageTracker == null)
			{
				Logging.LogMessage(String.Format("imageTracker null on {0}", name), "tappablestart");
			}
			else
			{
				Logging.LogMessage(String.Format("imageTracker not null on {0}", name), "tappablestart");
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
						Logging.LogMessage(String.Format("imageTracker null on {0}", name));

						OnTapped();

						if (imageTracker == null)
						{
							Logging.LogMessage(String.Format("imageTracker null on {0}", name), "tappableupdate");
						}
						else
						{
							Logging.LogMessage(String.Format("imageTracker not null on {0}", name), "tappableupdate");
						}

						MessageKit<string>.post((int)Messages.tapped, imageTracker.Id);
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
