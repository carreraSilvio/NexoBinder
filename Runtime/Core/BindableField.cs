using System;

namespace NexoBinder.Runtime.Core
{
    [Serializable]
    public class BindableField
    {
        public Action<object> OnValueChange;

        public virtual object Value
        {
            private get
            {
                return default;
            }
            set
            {
                OnValueChange?.Invoke(value);
            }
        }

        public BindableField() { }
    }
}
