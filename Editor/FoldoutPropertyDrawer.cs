using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEditor;
using UnityEngine;

namespace QOLAttributes
{
    [CustomPropertyDrawer(typeof(FoldoutAttribute))]
    public class FoldoutPropertyDrawer : PropertyDrawer
    {
        private bool _isFoldout;
        private List<SerializedProperty> _foldoutProperties;
        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
        {
            if (!(attribute as FoldoutAttribute).IsHeader) return;
            if (_foldoutProperties == null)
            {
                FindProperties(property);
            }

            return;
            var fInfo = property.serializedObject.targetObject.GetType().GetField(property.name, BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Public);
            var lvlv = fInfo.CustomAttributes.GetEnumerator();
            lvlv.MoveNext();
            lvlv.MoveNext();
            Debug.Log(lvlv.Current.AttributeType == typeof(FoldoutAttribute));
            var arg = lvlv.Current.ConstructorArguments;
            for (int i = 0; i < arg.Count; i++)
            {
                Debug.Log(arg[i].Value);
            }
            base.OnGUI(position, property, label);
            //property.serializedObject.forceChildVisibility = true;
        }
        private void FindProperties(SerializedProperty pProperty)
        {
            _foldoutProperties = new List<SerializedProperty>();
            _foldoutProperties.Add(pProperty);
            IEnumerator enumerator = pProperty.GetEnumerator();
            System.Type objType = pProperty.serializedObject.targetObject.GetType();
            while (pProperty.NextVisible(true))
            {
                System.Reflection.FieldInfo fInfo = objType.GetField(pProperty.name, BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Public);
                IEnumerator<CustomAttributeData> attrIEnum = fInfo.CustomAttributes.GetEnumerator();
                while (attrIEnum.MoveNext())
                {
                    CustomAttributeData attr = attrIEnum.Current;
                    if (attr.AttributeType == typeof(FoldoutAttribute))
                    {
                        _foldoutProperties.Add(pProperty);
                    }
                }
            }
        }
    }
}