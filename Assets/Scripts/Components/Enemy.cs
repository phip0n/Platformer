using UnityEngine;

[RequireComponent (typeof(EnemyMover))]
public class Enemy : MonoBehaviour
{
    [SerializeField] private PlayerDetector _detector;
    [SerializeField] private EnemyMover _enemyMover;
    [SerializeField] private Patroller _patroller;

    private void Update()
    {
        if (_detector != null && _detector.IsPlayerDetected)
        {
            _enemyMover.SetTarget(_detector.Target);
        }
        else if (_patroller != null)
        {
            _enemyMover.SetTarget(_patroller.Target);
        }
    }
}
