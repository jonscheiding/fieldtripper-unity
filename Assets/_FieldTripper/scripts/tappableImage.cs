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

        private void Update()
        {
            foreach (Touch touch in Input.touches)
            {
				Logging.LogMessage("Tap1");
                if (touch.phase == TouchPhase.Ended)
                {
				Logging.LogMessage("Tap2");
                    Ray ray = Camera.main.ScreenPointToRay(touch.position);
                    RaycastHit hit;
				Logging.LogMessage("Tap3");
                    if (Physics.Raycast(ray, out hit) == true)
                    {
				Logging.LogMessage("Tap4");
                        MessageKit<string>.post((int)Messages.tapped, imageTracker.Id);
				Logging.LogMessage("Tap5");
						OnTapped();
				Logging.LogMessage("Tap6");
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
