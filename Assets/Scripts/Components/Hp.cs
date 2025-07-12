using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;

public abstract class Hp : MonoBehaviour
{
    [SerializeField] protected Animator _animator;
    [SerializeField] private int _maxHp = 50;
    [SerializeField] private int _teamID;
    [SerializeField] private List<DyingComponent> _DyingComponents;

    private bool _isAlive = true;

    public int Points { get; private set; }
    public int TeamID => _teamID;

    public void Awake()
    {
        Init();
    }

    public void Heal(int hp)
    {
        Points += hp;

        if (Points > _maxHp)
            Points = _maxHp;
    }

    public void TakeDamage(int damage)
    {
        Points -= damage;

        if (Points <= 0 && _isAlive)
        {
            _isAlive = false;
            StartDying();
        }
    }

    protected virtual void StartDying()
    {
        foreach (var component in _DyingComponents)
        {
            component.StartDying();
        }
    }

    protected virtual void Init()
    {
        Points = _maxHp;
    }
}
