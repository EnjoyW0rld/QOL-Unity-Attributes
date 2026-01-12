using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace QOLAttributes
{
    [AttributeUsage(AttributeTargets.Field, AllowMultiple = false)]
    public class ReadOnlyAttribute : PropertyAttribute
    {
        
    }
}
