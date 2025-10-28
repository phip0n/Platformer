using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private Health _health;
    [SerializeField] private Wallet _wallet;
    [SerializeField] private Damager _damager;
    [SerializeField] private InputReader _inputReader;
    [SerializeField] private PlayerAnimator _animator;

    private void Update()
    {
        if (_damager != null && _inputReader != null && _inputReader.IsAttackActive)
        {
            bool isAttacking = _damager.TryAttack();

            if (isAttacking)
                _animator.Attack();
        }
    }

    public void Heal(int health)
    {
        _health.Heal(health);
    }

    public void TakeCoins(int coins)
    {
        _wallet.TakeCoins(coins);
    }
}