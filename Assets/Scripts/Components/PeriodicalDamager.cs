using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public abstract class PeriodicalDamager : MonoBehaviour
{
    [SerializeField] protected int Damage = 10;

    [SerializeField] private int _teamID;
    [SerializeField] private float _delay = 1;

    protected bool IsReady = true;
    protected List<Target> Targets;

    private WaitForSeconds _delayTime;

    private void Awake()
    {
        _delayTime = new WaitForSeconds(_delay);
        Targets = new List<Target>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent<Target>(out Target target) && target.TeamID != _teamID)
        {
            Targets.Add(target);

            if (IsReady)
                Attack();
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.TryGetComponent<Target>(out Target target))
        {
            Targets.Remove(target);
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.TryGetComponent<Target>(out Target target))
        {
            Targets.Remove(target); ;
        }
    }

    protected abstract void Attack();

    protected IEnumerator RechargeAttack()
    {
        yield return _delayTime;

        if (Targets.Count > 0)
        {
            Attack();
        }
        else
        {
            IsReady = true;
        }
    }
}