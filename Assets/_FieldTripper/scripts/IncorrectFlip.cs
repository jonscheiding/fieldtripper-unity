using Prime31.MessageKit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using DG.Tweening;

namespace Assets._FieldTripper.scripts
{
	public class IncorrectFlip : Answer
	{
		[SerializeField]
		private Texture2D newTexture;

		protected override void OnTapped()
		{
			Logging.LogMessage("IncorrectFlip.OnTapped()");

			base.OnTapped();

			Logging.LogMessage("Flipping");
			MyTrackedImage.ReferenceImage.imageTexture = newTexture;
			Logging.LogMessage("Flipped");
		}
	}
}
