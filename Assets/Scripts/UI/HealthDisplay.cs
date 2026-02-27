using UnityEngine;

public abstract class HealthDisplay : MonoBehaviour
{
    [SerializeField] protected Health Health;

    private void OnEnable()
    {
        Health.HealthChanged += Display;
    }

    private void OnDisable()
    {
        Health.HealthChanged -= Display;
    }

    abstract protected void Display();
}
