using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets._FieldTripper.scripts
{
    public class Logging
    {
		public static void LogMessage(string message, string tag = null)
		{
			if (tag != null)
			{
				LogMessage(message, new string[] { tag });
			}
		}

        public static void LogMessage(string message, string[] tags)
		{
            string formatted = format(message, tags);
            Debug.Log(formatted);
        }

		public static void LogError(string error, string tag = null)
		{
			if (tag != null)
			{
				LogError(error, new string[] { tag });
			}
		}

		public static void LogError(string error, string[] tags = null, bool throwException = false)
        {
            string formatted = format(error, tags);
            Debug.Log(formatted);

            if (throwException == true)
            {
                throw new Exception(formatted);
            }
        }

		private static string format(string message, string[] tags)
		{
			StringBuilder stringBuilder = new StringBuilder();
			if (tags != null)
			{
				bool first = true;
				foreach (string tag in tags)
				{
					if (first == false)
					{
						stringBuilder.Append(String.Format(", f_{0}", tag));
					}
					else
					{
						stringBuilder.Append(String.Format("ft_{0}", tag));
						first = false;
					}
				}
			}

			string formatted = string.Format("FTLog {0}: {1}", stringBuilder.ToString(), message);
			return formatted;
		}
	}
}
