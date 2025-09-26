using Unity.Mathematics;
using UnityEngine;

public class PlayerAnimator : DyingComponent
{
    [SerializeField] private GroundSensor _groundSensor;
    [SerializeField] private PlayerMover _mover;
    [SerializeField] private Animator _animator;
    [SerializeField] private InputReader _inputReader;

    private void Update()
    {
        if (_isAlive)
        {
            _animator.SetBool(PlayerAnimatorData.IsFallingID, !_groundSensor.isOnGround);
            _animator.SetFloat(PlayerAnimatorData.SpeedID, Mathf.Abs(_mover.Speed));
        }
    }

    public override void StartDying()
    {
        base.StartDying();
        _animator.SetTrigger(PlayerAnimatorData.DeathID);
    }
}