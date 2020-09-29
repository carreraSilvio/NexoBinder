using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Slider))]
public class SliderBinder : MonoBehaviour
{
    [SerializeField] private Slider _slider;
    [SerializeField] private FloatView _view;

    public void Reset()
    {
        _slider = GetComponent<Slider>();
        _view = GetComponentInParent<FloatView>();
    }

    public void Awake()
    {
        _view.OnSet += HandleEvent;
    }

    private void HandleEvent(float value)
    {
        _slider.value = value;
    }
}