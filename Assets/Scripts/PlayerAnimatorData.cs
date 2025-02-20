using UnityEngine;

public static class PlayerAnimatorData
{
    static PlayerAnimatorData()
    {
        SpeedID = Animator.StringToHash("Speed");
        IsFallingID = Animator.StringToHash("IsFalling");
    }

    public static int SpeedID { get; private set; }
    public static int IsFallingID { get; private set; }
}
