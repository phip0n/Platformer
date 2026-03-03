using UnityEngine;
using UnityEngine.UI;

[RequireComponent (typeof(Slider))]
public class SliderDisplay : MonoBehaviour
{
    protected Slider _slider;

    private void Awake()
    {
        _slider = GetComponent<Slider>();
    }

    public virtual void Init(float value)
    {
        _slider.value = value;
    }

    public virtual void Display(float value)
    {
        _slider.value = value;
    }
}
