using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace QOLAttributes
{

    [AttributeUsage(AttributeTargets.Field, AllowMultiple = false)]
    public class ShowIfAttribute : PropertyAttribute
    {
        public string ValueToComparer;
        public object TargetValue;
        public enum ComparisonType { Les, Equal, NotEqual, Bigger }
        public ComparisonType CompType;
        public ShowIfAttribute(ComparisonType pComparer, string pValueToCompare,object pTargetValue)
        {
            ValueToComparer = pValueToCompare;
            CompType = pComparer;
            TargetValue = pTargetValue;
        }
    }

}