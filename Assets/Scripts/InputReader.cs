using UnityEngine;

public class InputReader : MonoBehaviour
{
    [SerializeField] private PlayerMover _playerMover;

    public float XSpedRaw => Input.GetAxisRaw(InputData.Horizontal);
    public bool IsJumpActive => Input.GetKey(KeyCode.Space);
}
