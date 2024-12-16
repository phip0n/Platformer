using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(Rigidbody2D))]
public class Enemy : MonoBehaviour
{
    [SerializeField] float _speed;
    [SerializeField] float _minDistanseSqr;
    [SerializeField] Vector2[] _wayPoints;
    private int _currentPointIndex = 0;
    private Rigidbody2D _rigidBody;

    private void Awake()
    {
        _rigidBody = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        if (_wayPoints != null)
        {
            Vector2 direction = _wayPoints[_currentPointIndex] - new Vector2(transform.position.x, transform.position.y);

            if (direction.sqrMagnitude > _minDistanseSqr)
            {
                Vector2 speed = direction.normalized * _speed;
                _rigidBody.velocity = speed;
            }
            else
            {
                _rigidBody.velocity = Vector2.zero;
                _currentPointIndex = ++_currentPointIndex % _wayPoints.Length;
            }
        }
    }
}
