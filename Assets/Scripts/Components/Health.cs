using System;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] private int _maxHpealth = 50;
    [SerializeField] private int _teamID;
    [SerializeField] private List<DyingComponent> _DyingComponents;

    private bool _isAlive = true;

    public int MaxHealth => _maxHpealth;
    public int Points { get; private set; }
    public int TeamID => _teamID;

    public event Action HealthChanged;

    public void Awake()
    {
        Init();
    }

    public void Heal(int points)
    {
        if (points > 0)
        {
            Points += points;

            if (Points > _maxHpealth)
                Points = _maxHpealth;

            HealthChanged?.Invoke();
        }
    }

    public void TakeDamage(int damage)
    {
        if (damage > 0)
        {
            Points -= damage;

            if (Points <= 0 && _isAlive)
            {
                _isAlive = false;

                if (Points < 0)
                    Points = 0;

                StartDying();
            }

            HealthChanged?.Invoke();
        }
    }

    private void StartDying()
    {
        foreach (var component in _DyingComponents)
        {
            component.StartDying();
        }
    }

    private void Init()
    {
        Points = _maxHpealth;
    }
}
