using System;

namespace NexoBinder.Runtime.Core
{
	[Serializable]
	public class BindableField<T> : BindableField
	{
		public new T Value
		{
			get
			{
				return _value == null ? (T)default : (T)_value;
			}
			set
			{
				OnValueChange?.Invoke(value);
			}
		}

		public BindableField() { }
	}
}