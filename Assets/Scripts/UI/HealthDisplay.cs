using UnityEngine;

public abstract class HealthDisplay : MonoBehaviour
{
    [SerializeField] protected Health health;

    private void OnEnable()
    {
        health.HealthChanged += Display;
    }

    private void OnDisable()
    {
        health.HealthChanged -= Display;
    }

    abstract protected void Display();
}
