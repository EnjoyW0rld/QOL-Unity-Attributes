using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using System.Reflection;

namespace QOLAttributes
{

    [CustomPropertyDrawer(typeof(ShowIfAttribute))]
    public class ShowIfPropertyDrawer : PropertyDrawer
    {
        private FieldInfo propInfo;
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
            base.OnGUI(position, property, label);
        }
        public bool EvaluateShowIf(SerializedProperty pProperty)
        {
            ShowIfAttribute showIf = (ShowIfAttribute)attribute;
            switch (showIf.CompType)
            {
                case ShowIfAttribute.ComparisonType.Les:
                    break;
                case ShowIfAttribute.ComparisonType.Equal:
                    if (propInfo.GetValue(pProperty.serializedObject.targetObject).Equals(showIf.TargetValue))
                    {
                        return true;
                    }
                    break;
                case ShowIfAttribute.ComparisonType.NotEqual:
                    break;
                case ShowIfAttribute.ComparisonType.Bigger:
                    break;
            }

            return false;
        }

    }
}