using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerMover : MonoBehaviour
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
        _rigidBody.velocity = _velosity;
    }

    private void Update()
    {
        _animator.SetBool(PlayerAnimatorData.IsFallingID, !_groundSensor.isOnGround);
        _animator.SetFloat(PlayerAnimatorData.SpeedID, Mathf.Abs(_rigidBody.velocity.x));
        _velosity = _rigidBody.velocity;
        _velosity.x = _inputReader.XSpedRaw * _speed;

        if (_inputReader.IsJumpActive && _groundSensor.isOnGround)
        {
            _velosity.y = _jumpSpeed;
        }
    }
}