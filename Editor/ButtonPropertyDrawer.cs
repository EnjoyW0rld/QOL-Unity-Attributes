using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

namespace QOLAttributes
{
    [CustomPropertyDrawer(typeof(ButtonAttribute))]
    public class ButtonPropertyDrawer : PropertyDrawer
    {
        private float _buttonHeight = 40;
        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
        {
            position.height -= _buttonHeight;
            if (GUI.Button(position, label))
            {

            }
            position.y += _buttonHeight;
            EditorGUI.PropertyField(position, property, label);
            //EditorGUI.PropertyField(position, property, label);
        }
        public override float GetPropertyHeight(SerializedProperty property, GUIContent label)
        {
            return base.GetPropertyHeight(property, label) + _buttonHeight;
        }
    }
}