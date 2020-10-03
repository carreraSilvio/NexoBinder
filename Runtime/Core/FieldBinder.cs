using System;
using System.Reflection;
using UnityEngine;

namespace NexoBinder.Runtime.Core
{
	[Serializable]
	public abstract class FieldBinder : Binder<FieldBinderData>
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
			if (TargetMonoBehaviour == null)
			{
				return;
			}
			if (string.IsNullOrEmpty(TargetMemberName))
			{
				return;
			}

			FieldInfo targetFieldInfo = TargetMonoBehaviour.GetType().GetField(TargetMemberName, BINDING_FLAGS);

			if (targetFieldInfo == null)
			{
				Debug.LogWarning($"Field \"{TargetMemberName}\" not found in object of type {TargetMonoBehaviour.GetType().Name}.");
				return;
			}

            object targetFieldValue = targetFieldInfo.GetValue(TargetMonoBehaviour);

			if (targetFieldValue is BindableField targetBindableField)
			{
				_currentBindableField = targetBindableField;
				_currentBindableField.OnValueChange += valueChangeHandler;
			}
			else
			{
				Debug.LogWarning($"Field with name {TargetMemberName} not found in object of type {TargetMonoBehaviour.GetType().Name}.");
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

	[Serializable]
	public class FieldBinderData : BinderData
	{

	}
}