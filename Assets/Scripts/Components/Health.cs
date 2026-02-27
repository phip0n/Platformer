using System;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] private int _maxPoints = 50;
    [SerializeField] private int _teamID;

    private bool _isAlive = true;

    public int MaxPoints => _maxPoints;
    public int Points { get; private set; }
    public int TeamID => _teamID;

    public event Action HealthChanged;
    public event Action Dying;

    public void Awake()
    {
        Init();
    }

    public void TakeHeal(int points)
    {
        if (points > 0)
        {
            Points += points;

            points = Math.Clamp(points, 0, _maxPoints);

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

                Dying?.Invoke();
            }

            HealthChanged?.Invoke();
        }
    }

    private void Init()
    {
        Points = _maxPoints;
    }
}
