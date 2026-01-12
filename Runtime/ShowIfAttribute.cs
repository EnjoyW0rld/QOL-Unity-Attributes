using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//**************************
// ShowIf attribute allows to apply it to the property in class passing another variable in the same class
// allowing to hide or show the attribute depending on the passed value that serves as a comparer
//**************************
namespace QOLAttributes
{
    /// <summary>
    /// Attribute used on variables to hide or show them in the inspector
    /// </summary>
    [AttributeUsage(AttributeTargets.Field, AllowMultiple = false)]
    public class ShowIfAttribute : PropertyAttribute
    {
        public string ValueToComparer;
        public object TargetValue;
        public enum ComparisonType { Less, Equal, NotEqual, Bigger, IsNull, IsNotNull }
        public ComparisonType CompType;
        public ShowIfAttribute(string pValueToCompare, ComparisonType pComparer, object pTargetValue)
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
        public static bool IsNumber(object value)
        {
            return value is sbyte
                || value is byte
                || value is short
                || value is ushort
                || value is int
                || value is uint
                || value is long
                || value is ulong
                || value is System.Int16
                || value is System.Int32
                || value is System.Int64
                || value is System.UInt16
                || value is System.UInt32
                || value is System.UInt64
                || value is nint
                || value is nuint
                || value is float
                || value is double
                || value is decimal;
        }
    }

}