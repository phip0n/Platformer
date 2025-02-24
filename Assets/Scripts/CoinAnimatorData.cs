using UnityEngine;

public static class CoinAnimatorData
{
    static CoinAnimatorData()
    {
        DisappearID = Animator.StringToHash("Disappear");
    }

    public static int DisappearID { get; private set; }
}
