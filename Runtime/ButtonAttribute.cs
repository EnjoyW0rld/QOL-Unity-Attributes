using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace QOLAttributes
{
    [AttributeUsage(AttributeTargets.Field, AllowMultiple = false)]
    public class ButtonAttribute : PropertyAttribute
    {
        public bool DoDrawUnder;
        public string TargetFunction;
        public string DisplayName;
        /// <summary>
        /// Draws a button for a specified function
        /// </summary>
        /// <param name="pTargetFunction"></param>
        /// <param name="pDisplayName"></param>
        /// <param name="pDoDrawUnder"></param>
        public ButtonAttribute(string pTargetFunction, string pDisplayName, bool pDoDrawUnder = false)
        {
            DoDrawUnder = pDoDrawUnder;
            TargetFunction = pTargetFunction;
            DisplayName = pDisplayName;
        }
        /// <summary>
        /// Draws a button for a specified function, the text on the button will be identical to the function name
        /// </summary>
        /// <param name="pTargetFunction"></param>
        /// <param name="pDoDrawUnder"></param>
        public ButtonAttribute(string pTargetFunction, bool pDoDrawUnder = false)
        {
            DoDrawUnder = pDoDrawUnder;
            TargetFunction = pTargetFunction;
        }
    }
}