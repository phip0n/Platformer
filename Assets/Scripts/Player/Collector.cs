using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public class Collector : MonoBehaviour
{
    [SerializeField] private Player _player;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent(out Loot loot) && loot.IsActive)
        {
            if (_player != null)
            {
                loot.Interact(_player);
            }
        }
    }
}
