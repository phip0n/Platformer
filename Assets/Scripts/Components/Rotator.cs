using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Rotator : MonoBehaviour
{
    [SerializeField] private Transform _transform;

    private Quaternion _leftRotation = Quaternion.LookRotation(-Vector3.forward, Vector3.up);
    private Quaternion _rightRotation = Quaternion.LookRotation(Vector3.forward, Vector3.up);

    private void Awake()
    {
    }

    public void Rotate(float xSpeed)
    {
        if (xSpeed != 0)
        {
            _transform.rotation = xSpeed > 0 ? _rightRotation : _leftRotation;
        }
    }
}
