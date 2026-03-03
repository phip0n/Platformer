using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private Health _health;
    [SerializeField] private Wallet _wallet;
    [SerializeField] private PlayerDamager _damager;
    [SerializeField] private InputReader _inputReader;
    [SerializeField] private PlayerAnimator _animator;
    [SerializeField] private VampireActivator _vampireActivator;

    private void Update()
    {
        if (_inputReader.IsAttackActive)
        {
            bool isAttacking = _damager.TryAttack();

            if (isAttacking)
                _animator.Attack();
        }

        if (_inputReader.IsSkillActive)
        {
            _vampireActivator.TryStartCast();
        }
    }

    public void Heal(int health)
    {
        _health.TakeHeal(health);
    }

    public void TakeCoins(int coins)
    {
        _wallet.TakeCoins(coins);
    }
}