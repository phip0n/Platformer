using System.Collections;
using UnityEngine;

public class SmoothSliderDisplay : SliderDisplay
{
    [SerializeField] private float _changeSpeed = 1;

    private float _value;
    private float _displayedValue;
    private bool _isChanging = false;

    protected override void Init()
    {
        _value = Health.Points / Health.MaxPoints;
        _displayedValue = _value;
        _slider.value = _displayedValue;
    }

    protected override void Display()
    {
        _value = (float)Health.Points / Health.MaxPoints;

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