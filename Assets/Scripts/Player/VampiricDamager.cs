using UnityEngine;

public class VampiricDamager : PeriodicalDamager
{
    [SerializeField] private Health _health;

    private bool _isWorking = false;

    public void Activate()
    {
        _isWorking = true;

        if (IsReady)
            Attack();
    }

    public void Deactivate()
    {
        _isWorking = false;
    }

    protected override void Attack()
    {
        if (_isWorking && Targets.Count > 0)
        {
            Target closestTarget = Targets[0];
            float sqrDistance = (closestTarget.transform.position - transform.position).sqrMagnitude;

            IsReady = false;

            if (Targets.Count > 1)
            {
                for (int i = 1; i < Targets.Count; i++)
                {
                    if ((Targets[i].transform.position - transform.position).sqrMagnitude < sqrDistance)
                        closestTarget = Targets[i];
                }
            }

            closestTarget.TakeDamage(Damage);
            _health.TakeHeal(Damage);

            StartCoroutine(RechargeAttack());
        }
    }
}
