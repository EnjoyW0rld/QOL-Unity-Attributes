using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace QOLAttributes
{
    [AttributeUsage(AttributeTargets.Field, AllowMultiple = true)]
    public class ButtonAttribute : PropertyAttribute
    {
        public bool DoDrawUnder;
        public string TargetFunction;
        public ButtonAttribute(string pTargetFunction, bool pDoDrawUnder = false)
        {
            DoDrawUnder = pDoDrawUnder;
            TargetFunction = pTargetFunction;
        }
    }
}