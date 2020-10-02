using NexoBinder.Runtime.Core;
using UnityEngine;
using UnityEngine.UI;

namespace NexoBinder.Runtime.Binders
{
	/// <summary>
	/// Binder for Unity's <see cref="Text"/> Component
	/// </summary>
	[RequireComponent(typeof(Text))]
    public class TextBinder : MonoBehaviour
    {
        [SerializeField] private Text _text;
        public BindableField<int> score = new BindableField<int>();

        public void Reset()
        {
            _text = GetComponent<Text>();
        }

        public void Awake()
        {
            //_view = GetComponentInParent<BindField<string>>();

            //_view.OnValueChange += HandleOnValueChange;
        }

        private void HandleOnValueChange(string obj)
        {
            _text.text = obj;
        }
    }
}