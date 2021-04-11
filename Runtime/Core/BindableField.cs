using System;

namespace NexoBinder.Runtime
{
    [Serializable]
    public class BindableField
    {
        public object _value;
        public Action<object> OnValueChange;

        public virtual object Value
        {
            get
            {
                return _value;
            }
            set
            {
                _value = Value;
                OnValueChange?.Invoke(value);
            }
        }

        public BindableField() { }
    }
}
