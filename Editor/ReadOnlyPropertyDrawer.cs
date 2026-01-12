using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
namespace QOLAttributes
{
    [CustomPropertyDrawer(typeof(ReadOnlyAttribute))]
    public class ReadOnlyPropertyDrawer : PropertyDrawer
    {
        private bool foldoutState = false;
        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
        {
            if (property.hasVisibleChildren)
            {
                DrawNestedChildren(property,label);
                return;
            }
            //property.boxedValue;
            GUILayout.BeginHorizontal();
            GUILayout.Label(label);
            string val = property.boxedValue != null ? property.boxedValue.ToString() : "null";
            GUILayout.Label(val);
            GUILayout.EndHorizontal();
        }
        private void DrawNestedChildren(SerializedProperty pProperty, GUIContent pLabel)
        {
            foldoutState = EditorGUILayout.Foldout(foldoutState, pLabel);
            if (!foldoutState) return;
            IEnumerator num = pProperty.GetEnumerator();
            while (num.MoveNext())
            {
                //EditorGUILayout.PropertyField(num.Current as SerializedProperty);
                GUILayout.BeginHorizontal();
                GUILayout.Label(pProperty.displayName);
                string val = pProperty.boxedValue != null ? pProperty.boxedValue.ToString() : "null";
                GUILayout.Label(val);
                GUILayout.EndHorizontal();
            }
        }
        public override float GetPropertyHeight(SerializedProperty property, GUIContent label)
        {
            //return EditorGUI.GetPropertyHeight(property, label, true);
            return 0;
            return base.GetPropertyHeight(property, label);
        }
    }
}