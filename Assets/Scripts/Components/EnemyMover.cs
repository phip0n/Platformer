using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class EnemyMover : DyingComponent
{
    [SerializeField] private float _speed;
    [SerializeField] private float _minDistanseSqr;
    [SerializeField] private Vector2[] _wayPoints;
    [SerializeField] Rotator _rotator;

    private bool _isChasing = false;
    private Transform _player;
    private Vector2 _velocity;
    private int _currentPointIndex = 0;
    private Rigidbody2D _rigidBody;

    private void Awake()
    {
        _rigidBody = GetComponent<Rigidbody2D>();

        if (_wayPoints == null)
        {
            _wayPoints = new Vector2[] {new Vector2(transform.position.x, transform.position.y)};
        }
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

    public void StartChase(Transform player)
    {
        _isChasing = true;
        _player = player;
    }

    public void StopChase()
    {
        _isChasing = false;
    }

    public override void StartDying()
    {
        base.StartDying();
        _velocity = new Vector2(0, -_speed);
    }

    private void Move()
    {
        Vector2 target = _isChasing ? new Vector2(_player.position.x, _player.position.y) : _wayPoints[_currentPointIndex];
        Vector2 direction = target - new Vector2(transform.position.x, transform.position.y);

        if (direction.sqrMagnitude > _minDistanseSqr)
        {
            _velocity = direction.normalized * _speed;
        }
        else
        {
            _velocity = Vector2.zero;

            if (_isChasing == false)
                _currentPointIndex = ++_currentPointIndex % _wayPoints.Length;
        }

        _rotator.Rotate(_rigidBody.linearVelocity.x);
    }
}
