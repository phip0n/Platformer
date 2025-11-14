using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class EnemyMover : DyingComponent
{
    [SerializeField] private float _speed;
    [SerializeField] private float _minDistanseSqr;
    [SerializeField] Rotator _rotator;

    private Vector2 _target;
    private Vector2 _velocity;
    private Rigidbody2D _rigidBody;

    private void Awake()
    {
        _rigidBody = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        if (_isAlive)
            _rigidBody.linearVelocity = _velocity;
    }

    private void Update()
    {
        if (_isAlive)
            Move();
    }

    public void SetTarget(Vector2 target)
    {
        _target = target;
    }

    public override void StartDying()
    {
        base.StartDying();
    }

    private void Move()
    {
        Vector2 direction = _target - new Vector2(transform.position.x, transform.position.y);

        if (direction.sqrMagnitude > _minDistanseSqr)
        {
            _velocity = direction.normalized * _speed;
        }
        else
        {
            _velocity = Vector2.zero;
        }

        if (_rotator != null)
            _rotator.Rotate(_rigidBody.linearVelocity.x);
    }
}
