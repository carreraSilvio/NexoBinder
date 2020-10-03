using System;

namespace NexoBinder.Runtime.Core
{
	[Serializable]
	public class BindableField<T> : BindableField
	{
		public new T Value
		{
			private get
			{
				return (T)default;
			}
			set
			{
				OnValueChange?.Invoke(value);
			}
		}

		public BindableField() { }
	}
}