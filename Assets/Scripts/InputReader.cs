using UnityEngine;

public class InputReader : MonoBehaviour
{
    [SerializeField] private PlayerMover _playerMover;

    private void Start()
    {
        
    }

    private void Update()
    {
        _playerMover.SetHorizontalSpeed(Input.GetAxisRaw(InputData.Horizontal));

        if (Input.GetKey(KeyCode.Space))
        {
            _playerMover.Jump();
        }
    }
}
