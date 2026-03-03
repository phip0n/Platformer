using System;
using UnityEngine;
using System.Collections;
using static UnityEngine.GraphicsBuffer;

public class VampireActivator : MonoBehaviour
{
    [SerializeField] private float _rechargeRate;
    [SerializeField] private float _maxCharge;
    [SerializeField] private float _chargeConsumptionRate;
    [SerializeField] private SpriteRenderer _vampiricRenderer;
    [SerializeField] private VampiricDamager _damager;

    private float _currentCharge;
    private bool _isCasting = false;
    private bool _isCastReady = false;

    public event Action Casting;
    public event Action Recharging;
    public event Action Charged;
    public event Action<float> ChargeChanged;

    private void Awake()
    {
        _currentCharge = 0;
        _damager.enabled = false;
        StartCoroutine(StartRecharge());
    }

    public void TryStartCast()
    {
        if (_isCastReady)
        {
            Casting?.Invoke();
            _isCastReady = false;
            _isCasting = true;
            _vampiricRenderer.enabled = true;
            _damager.Activate();

            StartCoroutine(StartCasting());
        }
    }

    private IEnumerator StartCasting()
    {
        WaitForEndOfFrame waitForEndOfFrame = new WaitForEndOfFrame();

        while (_currentCharge > 0)
        {
            _currentCharge -= _chargeConsumptionRate* Time.deltaTime;
            ChargeChanged?.Invoke(_currentCharge / _maxCharge);
            yield return waitForEndOfFrame;
        }

        _isCasting = false;
        _vampiricRenderer.enabled = false;
        _damager.Deactivate();
        StartCoroutine(StartRecharge());
        _vampiricRenderer.enabled = false;
    }

    private IEnumerator StartRecharge()
    {
        WaitForEndOfFrame waitForEndOfFrame = new WaitForEndOfFrame();

        Recharging?.Invoke();

        while (_currentCharge < _maxCharge)
        {
            _currentCharge += _rechargeRate * Time.deltaTime;
            ChargeChanged?.Invoke(_currentCharge / _maxCharge);
            yield return waitForEndOfFrame;
        }

        _isCastReady = true;
        Charged?.Invoke();
    }
}
