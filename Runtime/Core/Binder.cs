using System;
using UnityEngine;

namespace NexoBinder.Runtime.Core
{
    public abstract class Binder : MonoBehaviour, IHasFieldBind
		//, IPreInitializable
	{
		[SerializeField] protected FieldBindMaker _binder = new FieldBindMaker();

		public Action<object> onValueChange;
		protected object _value;
		private bool _isBound;

		public object Value
		{
			get => _value;
			set
			{
				_value = value;
				onValueChange?.Invoke(value);
				HandleValueChange(value);
			}
		}

		public bool IsInitialized { get; set; }

		// Unity
		private void OnDestroy()
		{
			SetBind(false);
		}

		// Functions
		public virtual void PreInitialize()
		{
			if (_isBound) return;
			SetBind(true);
		}

		public void SetBind(bool add)
		{
			if (add && !_isBound)
			{
				_binder.AddBind(SetValue);
				SetValue(_binder.Value);
				_isBound = true;
			}
			else if (!add && _isBound)
			{
				_binder.RemoveBind(SetValue);
				HandleRemoveBind();
				_isBound = false;
			}
		}

		public virtual void SetValue(object value)
		{
			Value = value;
		}

		public virtual void HandleRemoveBind() { }

		// Override on children
		public virtual void HandleValueChange(object value)
		{
		}
	}

	public interface IHasFieldBind
	{
	}
}