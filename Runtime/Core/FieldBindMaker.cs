using System;
using System.Reflection;
using UnityEngine;

namespace NexoBinder.Runtime.Core
{
    [Serializable]
	public class FieldBindMaker : BindMaker
	{
		public object Value => _currentField?.Value;

		private BindableField _currentField;

        private static BindingFlags BINDING_FLAGS = BindingFlags.Default | BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic;

		public FieldBindMaker() { }

		public void AddBind(Action<object> valueChangeHandler)
		{
			if (_targetMonoBehaviour == null)
			{
				return;
			}
			if (string.IsNullOrEmpty(_targetFieldName))
			{
				return;
			}

			FieldInfo targetFieldInfo = _targetMonoBehaviour.GetType().GetField(_targetFieldName, BINDING_FLAGS);

			if (targetFieldInfo == null)
			{
				Debug.LogWarning($"Field \"{_targetFieldName}\" not found in object of type {_targetMonoBehaviour.GetType().Name}.");
				return;
			}

            object targetFieldValue = targetFieldInfo.GetValue(_targetMonoBehaviour);

			if (targetFieldValue is BindableField targetBindableField)
			{
				_currentField = targetBindableField;
				_currentField.OnValueChange += valueChangeHandler;
			}
			else
			{
				Debug.LogWarning($"Field with name {_targetFieldName} not found in object of type {_targetMonoBehaviour.GetType().Name}.");
				Debug.LogWarning("Bind not completed");
			}
		}

		public void RemoveBind(Action<object> valueChangeHandler)
		{
			if (_currentField != null)
			{
				_currentField.OnValueChange -= valueChangeHandler;
			}
		}
	}
}