using UnityEngine;

public class CameraMover : MonoBehaviour
{
    [SerializeField] private Transform _player;

    private Vector3 _position;

    private void LateUpdate()
    {
        if (_player != null)
        {
            _position = new Vector3(_player.position.x, _player.position.y, transform.position.z);
            transform.position = _position;
        }
    }
}
