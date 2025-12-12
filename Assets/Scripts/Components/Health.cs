using System;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] private int _maxHealth = 50;
    [SerializeField] private int _teamID;
    [SerializeField] private List<DyingComponent> _dyingComponents;

    private bool _isAlive = true;

    public int MaxHealth => _maxHealth;
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

            points = Math.Clamp(points, 0, _maxHealth);

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
        foreach (var component in _dyingComponents)
        {
            component.StartDying();
        }
    }

    private void Init()
    {
        Points = _maxHealth;
    }
}
