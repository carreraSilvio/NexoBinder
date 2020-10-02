using System;

namespace NexoBinder.Runtime.Core
{
    [Serializable]
	public class BindableField
	{
		protected object _value;
		public Action<object> OnValueChange;

		public virtual object Value
		{
			get
			{
				return _value;
			}
			set
			{
				_value = value;
				OnValueChange?.Invoke(value);
			}
		}

		public BindableField() { }

		public BindableField(object value)
		{
			_value = value;
		}

		public void HandleValueChange(object value)
		{
			Value = value;
		}
	}

	[Serializable]
	public class BindableField<T> : BindableField
	{
		public new T Value
		{
			get => _value != null ? (T)_value : default;
			set => base.Value = value;
		}

		public BindableField()
		{
		}

		public BindableField(object value)
		{
			_value = value;
		}
	}
}