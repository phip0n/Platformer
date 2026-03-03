using UnityEngine;

public class InputReader : MonoBehaviour
{
    private KeyCode _jumpKeyCode = KeyCode.Space;
    private KeyCode _attackKeyCode = KeyCode.E;
    private KeyCode _skillKeyKode = KeyCode.F;

    public float XSpedRaw { get; private set; }
    public bool IsJumpActive { get; private set; }
    public bool IsAttackActive { get; private set; }
    public bool IsSkillActive { get; private set; }

    private void Update()
    {
        XSpedRaw = Input.GetAxisRaw(InputData.Horizontal);
        IsJumpActive = Input.GetKey(_jumpKeyCode);
        IsAttackActive = Input.GetKey(_attackKeyCode);
        IsSkillActive = Input.GetKey(_skillKeyKode);
    }
}
