using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

namespace QOLAttributes
{
    [CustomPropertyDrawer(typeof(BreakAttribute))]
    public class BreakPropertyDrawer : PropertyDrawer
    {
        private static float _lineHeight => EditorGUIUtility.singleLineHeight;
        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
        {
            BreakAttribute brAttr = attribute as BreakAttribute;
            // Drawing break rectangle
            Rect r = new Rect(position);
            r.height = brAttr.BreakWidth;
            r.y = (_lineHeight - brAttr.BreakWidth)/2f;
            EditorGUI.DrawRect(r,brAttr.BreakColor);
            // Drawing property
            position.y += _lineHeight;
            position.height = base.GetPropertyHeight(property,label);
            EditorGUI.PropertyField(position, property, label);
        }
        public override float GetPropertyHeight(SerializedProperty property, GUIContent label)
        {
            return EditorGUI.GetPropertyHeight(property, label, true) + _lineHeight;
        }
    }
}