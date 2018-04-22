using Prime31.MessageKit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using DG.Tweening;

namespace Assets._FieldTripper.scripts
{
	public class IncorrectAnswer : Answer
	{
		protected override void OnTapped()
		{
			Logging.LogMessage("IncorrectAnswer.OnTapped()");

			base.OnTapped();

			Flash(Color.red);
		}
	}
}
