using UnityEngine;

public class DyingComponent : MonoBehaviour
{
    [SerializeField] private Health _health;
    protected bool IsAlive = true;

    private void OnEnable()
    {
        _health.Dying += StartDying;
    }

    private void OnDisable()
    {
        _health.Dying -= StartDying;
    }

    public virtual void StartDying()
    {
        IsAlive = false;
    }
}
