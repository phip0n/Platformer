using UnityEngine;
using System.Collections;

public class PlayerDamager: MonoBehaviour
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
        Collider2D[] colliders;

        if (_isReady)
        {
            colliders = Physics2D.OverlapCircleAll(transform.position, _range);
            _isReady = false;
            isAttacking = true;

            foreach (Collider2D collider in colliders)
            {
                if (collider.TryGetComponent(out Target target) && target.TeamID != _teamID)
                    target.TakeDamage(_damage);
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
