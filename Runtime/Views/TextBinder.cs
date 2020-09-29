using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Text))]
public class TextBinder : MonoBehaviour 
{
    [SerializeField] private StringView _view;
    [SerializeField] private Text _text;

    public void Reset()
    {
        _view = GetComponentInParent<StringView>();
        _text = GetComponent<Text>();
    }

    public void Awake()
    {
        _view.OnSet += HandleEvent;
    }

    private void HandleEvent(string obj)
    {
        _text.text = obj;
    }
}
