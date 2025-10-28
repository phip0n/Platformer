using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
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

    public void Heal(int points)
    {
        if (points > 0)
        {
            Points += points;

            if (Points > _maxHp)
                Points = _maxHp;
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
        Points = _maxHp;
    }
}
