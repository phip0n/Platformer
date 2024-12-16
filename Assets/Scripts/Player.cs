using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(Collider2D))]
public class Player : MonoBehaviour
{
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
        _animator = GetComponent<Animator>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.TryGetComponent(out Coin coin))
        {
            coin.InteractWithPlayer();
        }
    }

    private void Update()
    {
        _velosity = _rigidBody.velocity;
        _velosity.x = Input.GetAxisRaw("Horizontal") * _speed;

        if (_groundSensor.isOnGraund)
        {
            _animator.SetBool(PlayerAnimatorData.IsFallingID, false);
        }
        else
        {
            _animator.SetBool(PlayerAnimatorData.IsFallingID, true);
        }

        _animator.SetFloat(PlayerAnimatorData.SpeedID, Mathf.Abs(_rigidBody.velocity.x));

        if (Input.GetKey(KeyCode.Space) && _groundSensor.isOnGraund)
        {
            _velosity.y = _jumpSpeed;
        }

        _rigidBody.velocity = _velosity;
    }
}

public static class PlayerAnimatorData
{
    static PlayerAnimatorData()
    {
        SpeedID = Animator.StringToHash("Speed");
        IsFallingID = Animator.StringToHash("IsFalling");
    }

    public static int SpeedID { get; private set; }
    public static int IsFallingID { get; private set; }
}