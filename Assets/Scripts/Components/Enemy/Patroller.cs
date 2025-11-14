using System.Linq;
using UnityEngine;

public class Patroller : MonoBehaviour
{
    [SerializeField] private Vector2[] _wayPoints;
    [SerializeField] private float _minDistanseSqr = 0.1f;

    private int _currentPointIndex = 0;

    public Vector2 Target => _wayPoints[_currentPointIndex];

    private void Awake()
    {
        if (_wayPoints == null || _wayPoints.Count() == 0)
        {
            _wayPoints = new Vector2[] { new Vector2(transform.position.x, transform.position.y) };
        }
    }

    private void Update()
    {
        Vector2 direction = _wayPoints[_currentPointIndex] - new Vector2(transform.position.x, transform.position.y);

        if (direction.sqrMagnitude <= _minDistanseSqr)
        {
            _currentPointIndex = ++_currentPointIndex % _wayPoints.Length;
        }
    }
}
