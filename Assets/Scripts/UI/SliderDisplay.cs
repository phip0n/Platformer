using UnityEngine;
using UnityEngine.UI;

[RequireComponent (typeof(Slider))]
public class SliderDisplay : HealthDisplay
{
    protected Slider _slider;

    private void Awake()
    {
        _slider = GetComponent<Slider>();
    }

    private void Start()
    {
        Init();
    }

    protected virtual void Init()
    {
        Display();
    }

    protected override void Display()
    {
        _slider.value = (float)_health.Points / _health.MaxHealth;
    }
}
