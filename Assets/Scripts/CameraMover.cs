using UnityEngine;

public class CameraMover : MonoBehaviour
{
    [SerializeField] private Transform _player;

    private Vector3 position;

    void Start()
    {
        
    }

    void Update()
    {
        if (_player != null)
        {
            position = new Vector3(_player.position.x, _player.position.y, transform.position.z);
            transform.position = position;
        }
    }
}
