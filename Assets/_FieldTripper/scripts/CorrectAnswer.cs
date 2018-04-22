using DG.Tweening;
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

			Tweener tweener = Flash(Color.green);

			if (tweener != null)
			{
				Logging.LogMessage("Tweener not null");
				tweener.OnComplete(() =>
				{
					Logging.LogMessage("Triggering shade");
					MessageKit.LogObservers((int)Messages.raiseShade);
				});
			}
			else
			{
				Logging.LogMessage("Tweener null");
			}
		}
	}
}
