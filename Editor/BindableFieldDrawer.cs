using NexoBinder.Runtime.Core;
using UnityEditor;
using UnityEngine;

namespace NexoBinder.Editor
{
    [CustomPropertyDrawer(typeof(BindableField<>))]
    public class BindableFieldDrawer : PropertyDrawer
    {
        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
        {
            //Don't draw
        }

        public override float GetPropertyHeight(SerializedProperty property, GUIContent label)
        {
            return 0f;
        }
    }
}