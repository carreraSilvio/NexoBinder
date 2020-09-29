using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Text))]
public class TextBinder : MonoBehaviour 
{
    [SerializeField] private Text _text;
    [SerializeField] private TextView _view;

    public void Reset()
    {
        _text = GetComponent<Text>();
        _view = GetComponentInParent<TextView>();
    }

    public void Awake()
    {
        _view.OnTextChange += HandleEvent;
    }

    private void HandleEvent(string obj)
    {
        _text.text = obj;
    }
}
