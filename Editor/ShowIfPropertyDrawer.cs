using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using System.Reflection;
using System;

namespace QOLAttributes
{

    [CustomPropertyDrawer(typeof(ShowIfAttribute))]
    public class ShowIfPropertyDrawer : PropertyDrawer
    {
        private FieldInfo propInfo;
        private bool _isSeen;
        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
        {
            if (propInfo == null)
            {
                ShowIfAttribute showIf = attribute as ShowIfAttribute;
                propInfo = property.serializedObject.targetObject.GetType().GetField(showIf.ValueToComparer, BindingFlags.NonPublic | BindingFlags.Instance);
            }
            if (!EvaluateShowIf(property))
            {
                return;
            }
            EditorGUILayout.PropertyField(property, label);
            //base.OnGUI(position, property, label);
        }
        public override float GetPropertyHeight(SerializedProperty property, GUIContent label)
        {
            return 0;
        }
        private bool EvaluateShowIf(SerializedProperty pProperty)
        {
            ShowIfAttribute showIf = (ShowIfAttribute)attribute;
            object propertyValue = propInfo.GetValue(pProperty.serializedObject.targetObject);
            if (showIf.CompType == ShowIfAttribute.ComparisonType.IsNull || showIf.CompType == ShowIfAttribute.ComparisonType.IsNotNull)
            {
                return DoNullEvalutionCheck(propertyValue);
            }
            IComparable val1 = Convert.ChangeType(showIf.TargetValue, propertyValue.GetType()) as IComparable;
            IComparable val2 = propertyValue as IComparable;
            switch (showIf.CompType)
            {
                case ShowIfAttribute.ComparisonType.Less:
                    return val1.CompareTo(val2) > 0;
                case ShowIfAttribute.ComparisonType.Equal:
                    return val1.CompareTo(val2) == 0;
                case ShowIfAttribute.ComparisonType.NotEqual:
                    return val1.CompareTo(val2) != 0;
                case ShowIfAttribute.ComparisonType.Bigger:
                    return val1.CompareTo(val2) < 0;
            }

            return false;
        }
        private bool DoNullEvalutionCheck(object pPropertyValue)
        {
            bool isNullCheck = ((ShowIfAttribute)attribute).CompType == ShowIfAttribute.ComparisonType.IsNull;
            return (isNullCheck ? pPropertyValue.Equals(null) : !pPropertyValue.Equals(null));
        }
    }
}