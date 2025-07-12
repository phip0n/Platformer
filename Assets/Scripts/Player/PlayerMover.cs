using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerMover : DyingComponent
{
    [SerializeField] private InputReader _inputReader;
    [SerializeField] private float _speed;
    [SerializeField] private float _jumpSpeed;
    [SerializeField] private GroundSensor _groundSensor;
    [SerializeField] private Animator _animator;

    private Rigidbody2D _rigidBody;
    private Vector2 _velosity;

    private void Awake()
    {
        _velosity = new Vector2(0, 0);
        _rigidBody = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        _rigidBody.linearVelocity = _velosity;
    }

    private void Update()
    {
        if (_isAlive)
        {
            _animator.SetBool(PlayerAnimatorData.IsFallingID, !_groundSensor.isOnGround);
            _velosity = _rigidBody.linearVelocity;
            _velosity.x = _inputReader.XSpedRaw * _speed;
            _animator.SetFloat(PlayerAnimatorData.SpeedID, Mathf.Abs(_velosity.x));

            if (_inputReader.IsJumpActive && _groundSensor.isOnGround)
            {
                _velosity.y = _jumpSpeed;
            }
        }
    }

    public override void StartDying()
    {
        base.StartDying();
        _velosity = Physics2D.gravity * Time.deltaTime;
    }
}