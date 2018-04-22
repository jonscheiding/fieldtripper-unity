using DG.Tweening;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets._FieldTripper.scripts
{
	public class Answer : TappableImage
	{
		protected void Flash(Color color)
		{
			imageTracker.ReferenceMaterial.DOColor(color, 0.5f).SetLoops(2);
		}
	}
}
