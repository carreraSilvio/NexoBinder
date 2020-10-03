using NexoBinder.Runtime.Core;
using UnityEngine;
using UnityEngine.UI;

namespace NexoBinder.Runtime.Binders
{
    /// <summary>
    /// Binder for Unity's <see cref="Text"/> Component
    /// </summary>
    [AddComponentMenu("Nexo Binder/Text Binder")]
    [RequireComponent(typeof(Text))]
    public sealed class TextBinder : FieldBinder
    {
        [SerializeField] private Text _text;

        public void Reset()
        {
            _text = GetComponent<Text>();
        }

        protected override void HandleValueChange(object value)
        {
            if (value == null)
            {
                return;
            }

            string textValue = value.ToString();
            _text.text = textValue;
        }
    }
}