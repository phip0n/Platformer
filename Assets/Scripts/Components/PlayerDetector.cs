using UnityEngine;

public class PlayerDetector : MonoBehaviour
{
    [SerializeField] private EnemyMoover _enemy;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out PlayerHp playerHp))
        {
            _enemy.StartChase(playerHp);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out PlayerHp playerHp))
        {
            _enemy.StopChase();
        }
    }
}
