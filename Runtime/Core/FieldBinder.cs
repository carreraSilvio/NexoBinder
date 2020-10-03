using System;
using System.Reflection;
using UnityEngine;

namespace NexoBinder.Runtime.Core
{
    [Serializable]
	public abstract class FieldBinder : Binder<BinderData>
	{
		public bool IsBound => _isBound;

		private bool _isBound;

		private BindableField _currentBindableField;

        private static readonly BindingFlags BINDING_FLAGS = BindingFlags.Default | BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic;

		public FieldBinder() { }

		private void Awake()
		{
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
			if (targetMonoBehaviour == null)
			{
				return;
			}
			if (string.IsNullOrEmpty(targetMemberName))
			{
				return;
			}

			FieldInfo targetFieldInfo = targetMonoBehaviour.GetType().GetField(targetMemberName, BINDING_FLAGS);

			if (targetFieldInfo == null)
			{
				Debug.LogWarning($"Field \"{targetMemberName}\" not found in object of type {targetMonoBehaviour.GetType().Name}.");
				return;
			}

            object targetFieldValue = targetFieldInfo.GetValue(targetMonoBehaviour);

			if (targetFieldValue is BindableField targetBindableField)
			{
				_currentBindableField = targetBindableField;
				_currentBindableField.OnValueChange += valueChangeHandler;
			}
			else
			{
				Debug.LogWarning($"Field with name {targetMemberName} not found in object of type {targetMonoBehaviour.GetType().Name}.");
				Debug.LogWarning("Bind not completed");
			}

			_isBound = true;
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