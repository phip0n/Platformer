using System.Collections;
using UnityEngine;

public class PlayerHp : Hp
{
    [SerializeField] private float _dyingSeconds;
    [SerializeField] protected Character _character;

    private WaitForSeconds _dyingTime;

    protected override void Init()
    {
        base.Init();
        _dyingTime = new WaitForSeconds(_dyingSeconds);
    }

    protected override void StartDying()
    {
        base.StartDying();
        _animator.SetTrigger(PlayerAnimatorData.DeathID);
        StartCoroutine(Die());
    }

    private IEnumerator Die()
    {
        yield return _dyingTime;
        _character.Deactivate();
    }
}
