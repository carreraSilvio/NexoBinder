using System;
using System.Reflection;
using UnityEngine;

namespace NexoBinder.Runtime.Core
{
    [Serializable]
	public abstract class FieldBinder : Binder
	{
		protected bool _isBound;

		private BindableField _currentBindableField;

        private static readonly BindingFlags BINDING_FLAGS = BindingFlags.Default | BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic;

		public FieldBinder() { }

		private void Awake()
		{
			if (_isBound) return;
			AddBind(HandleValueChange);
		}

		private void OnDestroy()
		{
			RemoveBind(HandleValueChange);
		}

		private void AddBind(Action<object> valueChangeHandler)
		{
			if (_isBound)
			{
				return;
			}
			if (_targetMonoBehaviour == null)
			{
				return;
			}
			if (string.IsNullOrEmpty(_targetMemberName))
			{
				return;
			}

			FieldInfo targetFieldInfo = _targetMonoBehaviour.GetType().GetField(_targetMemberName, BINDING_FLAGS);

			if (targetFieldInfo == null)
			{
				Debug.LogWarning($"Field \"{_targetMemberName}\" not found in object of type {_targetMonoBehaviour.GetType().Name}.");
				return;
			}

            object targetFieldValue = targetFieldInfo.GetValue(_targetMonoBehaviour);

			if (targetFieldValue is BindableField targetBindableField)
			{
				_currentBindableField = targetBindableField;
				_currentBindableField.OnValueChange += valueChangeHandler;
			}
			else
			{
				Debug.LogWarning($"Field with name {_targetMemberName} not found in object of type {_targetMonoBehaviour.GetType().Name}.");
				Debug.LogWarning("Bind not completed");
			}
		}

		private void RemoveBind(Action<object> valueChangeHandler)
		{
			if(!_isBound)
            {
				return;
            }

			if (_currentBindableField != null)
			{
				_currentBindableField.OnValueChange -= valueChangeHandler;
			}
			_isBound = false;
		}

        protected abstract void HandleValueChange(object value);
	}
}