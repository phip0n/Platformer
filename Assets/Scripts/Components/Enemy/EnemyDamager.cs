using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class EnemyDamager : DyingComponent
{
    [SerializeField] private int _teamID;
    [SerializeField] private int _damage = 10;
    [SerializeField] private float _delay = 1;

    private bool _isReady = true;
    private List<Target> _targets;
    private WaitForSeconds _delayTime;

    private void Awake()
    {
        _delayTime = new WaitForSeconds(_delay);
        _targets = new List<Target>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent<Target>(out Target target) && target.TeamID != _teamID)
        {
            _targets.Add(target);

            if (_isReady)
                Attack();
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.TryGetComponent<Target>(out Target target))
        {
            _targets.Remove(target);
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.TryGetComponent<Target>(out Target target))
        {
            _targets.Remove(target); ;
        }
    }

    private void Attack()
    {
        if (IsAlive)
        {
            _isReady = false;

            foreach (Target target in _targets)
            {
                target.TakeDamage(_damage);
            }

            StartCoroutine(RechargeAttack());
        }
    }

    private IEnumerator RechargeAttack()
    {
        yield return _delayTime;

        if (_targets.Count > 0)
        {
            Attack();
        }
        else
        {
            _isReady = true;
        }
    }
}
