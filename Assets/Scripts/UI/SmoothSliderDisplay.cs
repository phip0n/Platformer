using System.Collections;
using UnityEngine;

public class SmoothSliderDisplay : SliderDisplay
{
    [SerializeField] private float _changeSpeed = 1;

    private float _value;
    private float _displayedValue;
    private bool _isChanging = false;

    public override void Init(float value)
    {
        _value = value;
        _displayedValue = value;
        _slider.value = value;
    }

    public override void Display(float value)
    {
        _value = value;

        if (_isChanging == false)
        {
            _isChanging = true;
            StartCoroutine(StartChanging());
        }
    }

    private IEnumerator StartChanging()
    {
        WaitForEndOfFrame _waitForEndOfFrame = new WaitForEndOfFrame();

        while (_value != _displayedValue)
        {
            _displayedValue = Mathf.MoveTowards(_displayedValue, _value, Time.deltaTime * _changeSpeed);
            _slider.value = _displayedValue;
            yield return _waitForEndOfFrame;
        }

        _isChanging = false;
    }
}