using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System.Reflection;
using NexoBinder.Runtime.Core;

namespace NexoBinder.Editor
{
	public class BinderDataDrawer<T> : PropertyDrawer where T  : BinderData
	{
		public const int BINDING_SETUP_OFFSET = 20;
		public static readonly Color BIND_NOT_SET_COLOR = new Color(1f, 0.4f, 0.4f);
		public static BindingFlags FIELD_FLAGS =
			BindingFlags.Instance |
			BindingFlags.Default |
			BindingFlags.Public |
			BindingFlags.NonPublic |
			BindingFlags.Static;

		protected MonoBehaviour _currentMonoBehaviour;
		protected T _currentBinderData = null;
		protected readonly List<BinderData> _binderList = new List<BinderData>();

		protected virtual bool IsObjectValid => _currentBinderData != null && _currentBinderData.targetMonoBehaviour != null;

		protected virtual string BinderTypeName => "Binder";

		private GUIStyle m_BindStyle;

		public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
		{
			_currentMonoBehaviour = (MonoBehaviour)property.serializedObject.targetObject;

			_currentBinderData = fieldInfo.GetValue(property.serializedObject.targetObject) as T;

			if (m_BindStyle == null)
			{
				m_BindStyle = new GUIStyle(GUI.skin.FindStyle("FrameBox"));
			}

			GetOptions(property);

			GUI.Box(position, "", m_BindStyle);

			var currentIndex = GetOptionSetIndex();
			var newIndex = currentIndex;
			var selectedOption = _binderList[currentIndex];

			// Property name label
			var binderLabelRect = position;
			binderLabelRect.x += 5;
			binderLabelRect.height = EditorGUIUtility.singleLineHeight;
			var labelStyle = new GUIStyle(GUI.skin.label);
			labelStyle.richText = true;

			var origColor = GUI.color;
			GUI.color = !IsObjectValid ? BIND_NOT_SET_COLOR : origColor;

			GUI.Label(binderLabelRect, label.text + $" <i>({typeof(T).Name})</i>", labelStyle);

			GUI.color = origColor;

			// Drop down
			var dropDownRect = position;
			dropDownRect.x += BINDING_SETUP_OFFSET;
			dropDownRect.y += EditorGUIUtility.singleLineHeight;
			dropDownRect.width = position.width - BINDING_SETUP_OFFSET - 5;
			dropDownRect.height = EditorGUIUtility.singleLineHeight;
			var dropDownStyle = new GUIStyle(GUI.skin.FindStyle("DropDownButton"));
			dropDownStyle.alignment = TextAnchor.MiddleLeft;

			dropDownRect = EditorGUI.PrefixLabel(dropDownRect, new GUIContent($"Target {BinderTypeName}"));

			var selectedLabel = $"{GetSelectedOptionName(selectedOption)}";
		
			if (GUI.Button(dropDownRect, selectedLabel, dropDownStyle))
			{
				GenericMenu menu = new GenericMenu();

				menu.AddItem(new GUIContent("None"), currentIndex == 0, () => SetNewPropertyField(default));

				for (int i = 1; i < _binderList.Count; i++)
				{
					var option = _binderList[i];
					menu.AddItem(new GUIContent(GetOptionName(option)), currentIndex == i, () => SetNewPropertyField(option));
				}

				menu.ShowAsContext();
			}

			GUI.color = Color.white;

			void SetNewPropertyField(BinderData binderData)
			{
				Undo.RecordObject(property.serializedObject.targetObject, "Set Property Bind");
				EditorUtility.SetDirty(property.serializedObject.targetObject);
                _currentBinderData.targetMonoBehaviour = binderData != null ? binderData.targetMonoBehaviour : null;
                _currentBinderData.targetMemberName = binderData != null ? binderData.targetMemberName : string.Empty;
            }

			// Binder target object
			if(IsObjectValid)
			{
				var objectFieldPos = dropDownRect;
				objectFieldPos.x = position.x + BINDING_SETUP_OFFSET;
				objectFieldPos.y += EditorGUIUtility.singleLineHeight;
				objectFieldPos.width = position.width - BINDING_SETUP_OFFSET - 5;
				objectFieldPos.height = EditorGUIUtility.singleLineHeight;
				objectFieldPos = EditorGUI.PrefixLabel(objectFieldPos, new GUIContent("Target Object"));
				EditorGUI.BeginDisabledGroup(true);
                EditorGUI.ObjectField(objectFieldPos, _currentBinderData.targetMonoBehaviour, typeof(T), true);
                EditorGUI.EndDisabledGroup();
			}
		}

		public override float GetPropertyHeight(SerializedProperty property, GUIContent label)
		{
			return EditorGUIUtility.singleLineHeight * (_currentBinderData != null && _currentBinderData.targetMonoBehaviour != null ? 3 : 2) + 5;
		}

		private int GetOptionSetIndex()
		{
			var obj = _currentBinderData.targetMonoBehaviour;
			var fieldName = _currentBinderData.targetMemberName;

			var index = _binderList.FindIndex(1, x => x.targetMonoBehaviour == obj && x.targetMemberName == fieldName);

			return Mathf.Max(0, index);
		}

		protected virtual void GetOptions(SerializedProperty property)
		{
			_binderList.Clear();
			//_binderList.Add(new Binder());
		}

		protected virtual string GetSelectedOptionName(BinderData binder)
		{
			if (binder.targetMonoBehaviour == null) return "None";

			var genericTypeName = GetBinderFieldGenericTypeName(binder);

			return $"{genericTypeName}{binder.targetMemberName}";
		}

		protected virtual string GetOptionName(BinderData binder)
		{
			if (binder.targetMonoBehaviour == null) return "None";

			var genericTypeName = GetBinderFieldGenericTypeName(binder);

			return $"({binder.targetMonoBehaviour.name}) {binder.targetMonoBehaviour.GetType().Name} / {genericTypeName}{binder.targetMemberName}";
		}

		protected virtual string GetBinderFieldGenericTypeName(BinderData binder)
		{
			var genericTypeName = "";
			var fieldType = binder.targetMonoBehaviour.GetType().GetField(binder.targetMemberName, FIELD_FLAGS)?.FieldType;
			if (fieldType != null && fieldType.IsGenericType)
			{
				genericTypeName = $"({fieldType.GenericTypeArguments[0].Name}) "; ;
			}
			return genericTypeName;
		}
	}

}
