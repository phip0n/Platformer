using UnityEngine;

public abstract class HealthDisplay : MonoBehaviour
{
    [SerializeField] protected Health _health;

    private void OnEnable()
    {
        _health.HealthChanged += Display;
    }

    private void OnDisable()
    {
        _health.HealthChanged -= Display;
    }

    abstract protected void Display();
}
