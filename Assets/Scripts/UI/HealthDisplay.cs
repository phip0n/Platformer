using UnityEngine;

[RequireComponent (typeof(SliderDisplay))]
public  class HealthDisplay : MonoBehaviour
{
    [SerializeField] private Health _health;

    private SliderDisplay _slider;

    private void Awake()
    {
        _slider = GetComponent<SliderDisplay>();
    }

    private void Start()
    {
        _slider.Init(GetSliderValue());
    }

    private void OnEnable()
    {
        _health.ValueChanged += Display;
    }

    private void OnDisable()
    {
        _health.ValueChanged -= Display;
    }

    private void Display()
    {
        _slider.Display(GetSliderValue());
    }

    private float GetSliderValue()
    {
        return (float)_health.Points / _health.MaxPoints;
    }
}
