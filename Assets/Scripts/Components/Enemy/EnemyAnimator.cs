using UnityEngine;

public class EnemyAnimator : DyingComponent
{
    [SerializeField] private Animator _animator;

    protected override void StartDying()
    {
        base.StartDying();
        _animator.SetTrigger(EnemyAnimatorData.DeathID);
    }
}
