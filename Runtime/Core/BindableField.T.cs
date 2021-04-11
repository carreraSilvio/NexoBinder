using System;

namespace NexoBinder.Runtime
{
    [Serializable]
    public class BindableField<T> : BindableField
    {
        public new T Value
        {
            get
            {
                return _value == null ? default : (T)_value;
            }
            set
            {
                OnValueChange?.Invoke(value);
            }
        }

        public BindableField() { }
    }
}