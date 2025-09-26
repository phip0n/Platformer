using UnityEngine;
using System;

[RequireComponent(typeof(Collider2D))]
public class HealthCatcher : MonoBehaviour
{
    [SerializeField] private Health _health;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent(out Healer healer) && healer.IsActive)
        {
            if (_health != null)
            {
                _health.Heal(healer.Health);
            }

            healer.Interact();
        }
    }
}
