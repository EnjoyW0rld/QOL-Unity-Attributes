using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace QOLAttributes
{
    [AttributeUsage(AttributeTargets.Field,Inherited = true, AllowMultiple = false)]
    public class FoldoutAttribute : PropertyAttribute
    {
        public string FoldoutName;
        public FoldoutAttribute(string pFoldoutName)
        {
            FoldoutName = pFoldoutName;
        }
    }
}