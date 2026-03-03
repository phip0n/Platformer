using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class EnemyDamager : PeriodicalDamager
{
    protected override void Attack()
    {
        IsReady = false;

        foreach (Target target in Targets)
        {
            target.TakeDamage(Damage);
        }

        StartCoroutine(RechargeAttack());
    }
}