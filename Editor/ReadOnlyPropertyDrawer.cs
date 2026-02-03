using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UIElements;
namespace QOLAttributes
{
    [CustomPropertyDrawer(typeof(ReadOnlyAttribute))]
    public class ReadOnlyPropertyDrawer : PropertyDrawer
    {
        private const int HORIZONTAL_PADDING = 30;
        private static float singleLineHeight => EditorGUIUtility.singleLineHeight;
        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
        {
            if (property.hasVisibleChildren)
            {
                DrawNestedChildren(position, property, label);
                return;
            }

            string val = property.boxedValue != null ? property.boxedValue.ToString() : "null";
            EditorGUI.LabelField(position, label, new GUIContent(val));
        }
        private void DrawNestedChildren(Rect pPosition, SerializedProperty pProperty, GUIContent pLabel)
        {
            EditorGUI.BeginProperty(pPosition, pLabel, pProperty);
            Rect foldoutPos = new Rect(pPosition.x, pPosition.y, pPosition.width, singleLineHeight);
            pProperty.isExpanded = EditorGUI.Foldout(foldoutPos, pProperty.isExpanded, pLabel);
            if (pProperty.isExpanded)
            {
                float addY = singleLineHeight;
                IEnumerator num = pProperty.GetEnumerator();
                while (num.MoveNext())
                {
                    string val = pProperty.boxedValue != null ? pProperty.boxedValue.ToString() : "null";
                    Rect propRect = new Rect(pPosition.x + HORIZONTAL_PADDING, pPosition.y + addY, pPosition.width, EditorGUI.GetPropertyHeight(pProperty));
                    EditorGUI.LabelField(propRect, pProperty.displayName, val);
                    addY += propRect.height;
                }

            }
            EditorGUI.EndProperty();
        }

        public override float GetPropertyHeight(SerializedProperty property, GUIContent label)
        {
            return EditorGUI.GetPropertyHeight(property, label, true);
        }
    }
}