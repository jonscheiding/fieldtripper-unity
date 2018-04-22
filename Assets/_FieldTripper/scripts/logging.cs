using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets._FieldTripper.scripts
{
    public class Logging
    {
        public static void LogMessage(string message)
        {
            string formatted = format(message);
            Debug.Log(formatted);
        }

        private static string format(string message)
        {
            string formatted = string.Format("FTLog: {0}", message);
            return formatted;
        }

        public static void LogError(string error, bool throwException = false)
        {
            string formatted = format(error);
            Debug.Log(formatted);

            if (throwException == true)
            {
                throw new Exception(formatted);
            }
        }
    }
}
