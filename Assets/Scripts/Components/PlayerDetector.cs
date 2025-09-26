using UnityEngine;

public class PlayerDetector : MonoBehaviour
{
    [SerializeField] private EnemyMover _enemy;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out Player player))
        {
            _enemy.StartChase(player);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out Player player))
        {
            _enemy.StopChase();
        }
    }
}
