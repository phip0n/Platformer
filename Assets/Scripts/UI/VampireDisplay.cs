using System;
using UnityEngine;
using UnityEngine.UI;

public class VampireDisplay : MonoBehaviour
{
    [SerializeField] private VampireActivator _vampireActivator;
    [SerializeField] private SliderDisplay _slider;
    [SerializeField] private Image sliderFillImage;
    [SerializeField] private Color _readyColor;
    [SerializeField] private Color _castColor;
    [SerializeField] private Color _rechargeColor;

    private void OnEnable()
    {
        _vampireActivator.Casting += SetCastColor;
        _vampireActivator.Recharging += SetRechargeColor;
        _vampireActivator.Charged += SetReadyColor;
        _vampireActivator.ChargeChanged += SetSliderValue;
    }

    private void OnDisable()
    {
        _vampireActivator.Casting -= SetCastColor;
        _vampireActivator.Recharging -= SetRechargeColor;
        _vampireActivator.Charged -= SetReadyColor;
        _vampireActivator.ChargeChanged -= SetSliderValue;
    }

    private void SetSliderValue(float value)
    {
        _slider.Display(value);
    }

    private void SetReadyColor()
    {
        sliderFillImage.color = _readyColor;
    }

    private void SetCastColor()
    {
        sliderFillImage.color = _castColor;
    }

    private void SetRechargeColor()
    {
        sliderFillImage.color = _rechargeColor;
    }
}
