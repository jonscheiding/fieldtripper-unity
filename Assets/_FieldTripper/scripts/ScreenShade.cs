using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using Prime31.MessageKit;

namespace Assets._FieldTripper.scripts
{
	public class ScreenShade : MonoBehaviour
	{
		[SerializeField]
		private Image ShadeImage;

		private void Start()
		{
			DoLower(0.0f);

			MessageKit.addObserver((int)Messages.raiseShade, Raise);
			MessageKit.addObserver((int)Messages.lowerShade, Lower);
		}

		private void OnDestroy()
		{
			MessageKit.removeObserver((int)Messages.raiseShade, Raise);
			MessageKit.removeObserver((int)Messages.lowerShade, Lower);
		}

		private void Raise()
		{
			Logging.LogMessage("Raising shade");
			ShadeImage.rectTransform.DOAnchorPos(Vector2.zero, 1.0f);
		}

		private void Lower()
		{
			Logging.LogMessage("Lowering shade");
			DoLower(1.0f);
		}

		private void DoLower(float duration = 1.0f)
		{
			ShadeImage.rectTransform.DOAnchorPos(new Vector2(0.0f, -Screen.height), duration);
		}

	}
}
