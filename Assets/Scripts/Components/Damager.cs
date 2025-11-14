using UnityEngine;
using System.Collections;

public class Damager: DyingComponent
{
    [SerializeField] private int _teamID;
    [SerializeField] private int _damage = 10;
    [SerializeField] private float _delay = 1;
    [SerializeField] private float _range = 2;

    private bool _isReady = true;
    private WaitForSeconds _delayTime;

    private void Awake()
    {
        _delayTime = new WaitForSeconds(_delay);
    }

    public bool TryAttack()
    {
        bool isAttacking = false;
        Collider2D[] _targets;

        if (_isAlive && _isReady)
        {
            _targets = Physics2D.OverlapCircleAll(transform.position, _range);
            _isReady = false;
            isAttacking = true;

            foreach (Collider2D target in _targets)
            {
                if (target.TryGetComponent(out Health health) && health.TeamID != _teamID)
                    health.TakeDamage(_damage);
            }

            StartCoroutine(RechargeAttack());
        }

        return isAttacking;
    }

    private IEnumerator RechargeAttack()
    {
        yield return _delayTime;

        _isReady = true;
    }
}
