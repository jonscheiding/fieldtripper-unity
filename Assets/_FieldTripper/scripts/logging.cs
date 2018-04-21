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
            Debug.Log(message);
        }

        public static void LogError(string error, bool throwException = false)
        {
            Debug.Log(error);

            if (throwException == true)
            {
                throw new Exception(error);
            }
        }
    }
}
