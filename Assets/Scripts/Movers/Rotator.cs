using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Rotator : MonoBehaviour
{
    [SerializeField] private Transform _transform;

    private Rigidbody2D _rigidBody;
    private Quaternion _leftRotation = Quaternion.LookRotation(-Vector3.forward, Vector3.up);
    private Quaternion _rightRotation = Quaternion.LookRotation(Vector3.forward, Vector3.up);

    private void Awake()
    {
        _rigidBody = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        Rotate();
    }

    private void Rotate()
    {
        if (_rigidBody.velocity.x != 0)
        {
            _transform.rotation = _rigidBody.velocity.x > 0 ? _rightRotation : _leftRotation;
        }
    }
}
