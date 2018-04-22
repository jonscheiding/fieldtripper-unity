using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets._FieldTripper.scripts
{
    public class Logging
    {
        public static void LogMessage(string message, string[] tags = null)
        {
            string formatted = format(message, tags);
            Debug.Log(formatted);
        }

        private static string format(string message, string[] tags = null)
        {
			StringBuilder stringBuilder = new StringBuilder();
			if (tags != null)
			{
				bool first = true;
				foreach (string tag in tags)
				{
					if (first == false)
					{
						stringBuilder.Append(String.Format(", {0}", tag));
					}
					else
					{
						stringBuilder.Append(tag);
						first = false;
					}
				}
			}

            string formatted = string.Format("FTLog {0}: {1}", stringBuilder.ToString(), message);
            return formatted;
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
    }
}
