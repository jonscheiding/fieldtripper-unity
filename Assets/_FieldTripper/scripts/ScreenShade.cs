using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using UnityEngine.UI;

namespace Assets._FieldTripper.scripts
{
	public class ScreenShade : MonoBehaviour
	{
		[SerializeField]
		private Image ShadeImage;

		private void Start()
		{
			ShadeImage.rectTransform.anchoredPosition = new Vector2(0.0f, -Screen.height);
			ShadeImage.transform.Translate(new Vector3(0.0f, 100.0f, 0.0f));
		}
	}
}
