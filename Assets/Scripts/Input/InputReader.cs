using UnityEngine;

public class InputReader : MonoBehaviour
{
    public float XSpedRaw { get; private set; }
    public bool IsJumpActive { get; private set; }

    private void Update()
    {
        XSpedRaw = Input.GetAxisRaw(InputData.Horizontal);
        IsJumpActive = Input.GetKey(KeyCode.Space);
    }
}
