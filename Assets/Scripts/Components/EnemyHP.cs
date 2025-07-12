using UnityEngine;

public class EnemyHP : Hp
{
    protected override void StartDying()
    {
        base.StartDying();
        _animator.SetTrigger(EnemyAnimatorData.DeathID);
    }
}
