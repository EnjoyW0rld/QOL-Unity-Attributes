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
        public enum ComparisonType { Less, Equal, NotEqual, Bigger, IsNull, IsNotNull }
        public ComparisonType CompType;
        public ShowIfAttribute(ComparisonType pComparer, string pValueToCompare, object pTargetValue)
        {
            ValueToComparer = pValueToCompare;
            CompType = pComparer;
            TargetValue = pTargetValue;
        }
        /// <summary>
        /// Constructor used ONLY for null/not null comparion, make sure
        /// nullable type is passed, otherwise it would not work
        /// </summary>
        /// <param name="pValueToCompare"></param>
        /// <param name="pComparer">Can only be IsNull and IsNotNull</param>
        public ShowIfAttribute(string pValueToCompare, ComparisonType pComparer = ComparisonType.IsNotNull)
        {
            ValueToComparer = pValueToCompare;
            if (pComparer != ComparisonType.IsNull && pComparer != ComparisonType.IsNotNull)
            {
                Debug.LogError($"Using shot attribute constructor wrong! Passed compare value - {pComparer} is incorrect for this type of construcor!");
                CompType = ComparisonType.IsNotNull;
                return;
            }
            CompType = pComparer;
        }
    }

}