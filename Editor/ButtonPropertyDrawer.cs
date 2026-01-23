using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UIElements;

namespace QOLAttributes
{
    [CustomPropertyDrawer(typeof(ButtonAttribute))]
    public class ButtonPropertyDrawer : PropertyDrawer
    {
        private float _buttonHeight = 20;
        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
        {
            ButtonAttribute bAttr = attribute as ButtonAttribute;
            string displayName = bAttr.DisplayName == null ? bAttr.TargetFunction : bAttr.DisplayName;
            if (bAttr.DoDrawUnder)
            {
                DrawButtonUnderProperty(position, property, label,displayName, bAttr);
            }
            else
            {
                DrawButtonAboveProperty(position, property, label, displayName, bAttr);
            }

        }
        private void DrawButtonAboveProperty(Rect position, SerializedProperty property, GUIContent label, string pDisplayName, ButtonAttribute bAttr)
        {
            position.height -= _buttonHeight;
            Rect buttonRect = new Rect(position);
            buttonRect.height = _buttonHeight;
            if (GUI.Button(buttonRect, pDisplayName))
            {
                string methodName = bAttr.TargetFunction;
                System.Reflection.MethodInfo functionInfo = property.serializedObject.targetObject.GetType().GetMethod(methodName, System.Reflection.BindingFlags.Public | System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance);
                functionInfo.Invoke(property.serializedObject.targetObject, null);
            }
            position.y += _buttonHeight;
            EditorGUI.PropertyField(position, property, label);
        }
        private void DrawButtonUnderProperty(Rect position, SerializedProperty property, GUIContent label,string pDisplayName, ButtonAttribute bAttr)
        {
            position.height -= _buttonHeight;
            EditorGUI.PropertyField(position, property, label);
            position.y += _buttonHeight;
            if (GUI.Button(position, pDisplayName))
            {
                string methodName = bAttr.TargetFunction;
                System.Reflection.MethodInfo functionInfo = property.serializedObject.targetObject.GetType().GetMethod(methodName, System.Reflection.BindingFlags.Public | System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance);
                functionInfo.Invoke(property.serializedObject.targetObject, null);
            }
        }
        public override float GetPropertyHeight(SerializedProperty property, GUIContent label)
        {
            return base.GetPropertyHeight(property, label) + _buttonHeight;
        }
    }
}