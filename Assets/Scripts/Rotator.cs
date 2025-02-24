using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Rotator : MonoBehaviour
{
    [SerializeField] private Transform _transform;

    private Rigidbody2D _rigidBody;

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
            _transform.rotation = Quaternion.LookRotation(Vector3.forward * _rigidBody.velocity.x, transform.up);
        }
    }
}
