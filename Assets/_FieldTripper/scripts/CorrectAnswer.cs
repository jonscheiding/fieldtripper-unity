using Prime31.MessageKit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets._FieldTripper.scripts
{
    public class CorrectAnswer : Answer
    {
		protected override void OnTapped()
		{
			Logging.LogMessage("CorrectAnswer.OnTapped()");

			base.OnTapped();

			Flash(Color.green);
		}
	}
}
