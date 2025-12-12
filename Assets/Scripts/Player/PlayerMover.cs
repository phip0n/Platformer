using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerMover : DyingComponent
{
    [SerializeField] private InputReader _inputReader;
    [SerializeField] private float _speed;
    [SerializeField] private float _jumpSpeed;
    [SerializeField] private GroundSensor _groundSensor;
    [SerializeField] Rotator _rotator;

    private Rigidbody2D _rigidBody;
    private Vector2 _velosity;

    public float Speed { get; private set; } = 0;

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
            _velosity = _rigidBody.linearVelocity;
            Speed = _inputReader.XSpedRaw * _speed;
            _velosity.x = Speed;
            _rotator.Rotate(Speed);

            if (_inputReader.IsJumpActive && _groundSensor.IsOnGround)
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