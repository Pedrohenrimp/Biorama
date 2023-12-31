using UnityEngine;
using UnityEditor;

namespace Biorama.Essentials
{
    #if UNITY_EDITOR
    [CustomPropertyDrawer(typeof(CustomNameAttribute))]
    public class CustomNameDrawer : PropertyDrawer
    {
        public override void OnGUI(Rect aPosition, SerializedProperty aProperty, GUIContent aLabel)
        {
            CustomNameAttribute att = (CustomNameAttribute)attribute;
            EditorGUI.PropertyField(aPosition, aProperty, new GUIContent(att.CustomName));
        }
    }
    #endif
}



