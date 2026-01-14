using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

namespace QOLAttributes
{
    [CustomPropertyDrawer(typeof(FoldoutAttribute))]
    public class FoldoutPropertyDrawer : PropertyDrawer
    {
        private bool _isFoldout;
        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
        {
            var al = property.boxedValue.GetType().GetFields();
            for (int i = 0; i < al.Length; i++)
            {
                var v = al[i].CustomAttributes.GetEnumerator();
                v.MoveNext();
                Debug.Log(v.Current);
            }
            base.OnGUI(position, property, label);
            //property.serializedObject.forceChildVisibility = true;
        }
    }
}