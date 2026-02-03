using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace QOLAttributes
{
    [AttributeUsage(AttributeTargets.Field, Inherited = true, AllowMultiple = false)]
    public class BreakAttribute : PropertyAttribute
    {
        public float BreakWidth = 1;
        public Color BreakColor = Color.white;
        public BreakAttribute() { }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="pBreakColor"></param>
        /// <param name="pBreakWidth">Break width in pixels</param>
        public BreakAttribute(Color pBreakColor, float pBreakWidth = 1)
        {
            this.BreakWidth = pBreakWidth;
            BreakColor = pBreakColor;
        }
        public BreakAttribute(float pBreakWidth)
        {
            BreakWidth = pBreakWidth;
        }

    }
}