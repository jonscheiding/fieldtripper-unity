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
		protected Tweener Flash(Color color)
		{
			Tweener tweener = null;

			if (MyTrackedImage != null && MyTrackedImage.ReferenceMaterial != null)
			{
				tweener = MyTrackedImage.ReferenceMaterial.DOColor(color, 0.5f).SetLoops(2);
			}

			return tweener;
		}

		protected void Flip(Texture2D newTexture)
		{
			
		}
	}
}
