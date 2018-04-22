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
                if (touch.phase == TouchPhase.Ended)
                {
                    Ray ray = Camera.main.ScreenPointToRay(touch.position);
                    RaycastHit hit;
                    if (Physics.Raycast(ray, out hit) == true)
                    {
                        MessageKit<string>.post((int)Messages.tapped, imageTracker.Id);
						OnTapped();
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
