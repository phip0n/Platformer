using UnityEngine;

public class EnemyAnimator : DyingComponent
{
    [SerializeField] private Animator _animator;

    public override void StartDying()
    {
        base.StartDying();
        _animator.SetTrigger(EnemyAnimatorData.DeathID);
    }
}
