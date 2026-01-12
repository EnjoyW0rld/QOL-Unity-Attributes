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
        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
        {
            if (propInfo == null)
            {
                ShowIfAttribute showIf = attribute as ShowIfAttribute;
                propInfo = property.serializedObject.targetObject.GetType().GetField(showIf.ValueToComparer, BindingFlags.NonPublic | BindingFlags.Instance);
            }
            if (!EvaluateShowIf(property,attribute,propInfo))
            {
                return;
            }
            EditorGUILayout.PropertyField(property, label);
        }
        public override float GetPropertyHeight(SerializedProperty property, GUIContent label)
        {
            //return EditorGUI.GetPropertyHeight(property, label, true);

            return 0;
        }
        /// <summary>
        /// Evaluates the value of the target field (the one to be compared to) to the passed value
        /// Also serves for the isNull/isNotNull cases
        /// </summary>
        /// <param name="pComparedProperty">Property that is compared, dynamic value</param>
        /// <param name="pAttachedAttribute">Property to that attribute is attached to</param>
        /// <param name="pComparedPropInfo">Info about the dynamic property that is being compared</param>
        /// <returns></returns>
        private static bool EvaluateShowIf(SerializedProperty pComparedProperty, PropertyAttribute pAttachedAttribute, FieldInfo pComparedPropInfo)
        {
            ShowIfAttribute showIf = (ShowIfAttribute)pAttachedAttribute;
            object propertyValue = pComparedPropInfo.GetValue(pComparedProperty.serializedObject.targetObject);
            if (showIf.CompType == ShowIfAttribute.ComparisonType.IsNull || showIf.CompType == ShowIfAttribute.ComparisonType.IsNotNull)
            {
                return DoNullEvalutionCheck(propertyValue, pAttachedAttribute);
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
        private static bool DoNullEvalutionCheck(object pPropertyValue, PropertyAttribute pAttribute)
        {
            bool isNullCheck = ((ShowIfAttribute)pAttribute).CompType == ShowIfAttribute.ComparisonType.IsNull;
            return (isNullCheck ? pPropertyValue.Equals(null) : !pPropertyValue.Equals(null));
        }
    }
}