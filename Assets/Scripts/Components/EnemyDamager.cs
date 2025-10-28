using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class EnemyDamager : DyingComponent
{
    [SerializeField] private int _teamID;
    [SerializeField] private int _damage = 10;
    [SerializeField] private float _delay = 1;

    private bool _isReady = true;
    private List<Health> _targets;
    private WaitForSeconds _delayTime;

    private void Awake()
    {
        _delayTime = new WaitForSeconds(_delay);
        _targets = new List<Health>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent<Health>(out Health hp) && hp.TeamID != _teamID)
        {
            _targets.Add(hp);

            if (_isReady)
                Attack();
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.TryGetComponent<Health>(out Health hp))
        {
            _targets.Remove(hp);
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.TryGetComponent<Health>(out Health hp))
        {
            _targets.Remove(hp); ;
        }
    }

    private void Attack()
    {
        if (_isAlive)
        {
            _isReady = false;

            foreach (Health hp in _targets)
            {
                hp.TakeDamage(_damage);
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
