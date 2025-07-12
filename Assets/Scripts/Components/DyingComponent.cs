using UnityEngine;

public class DyingComponent : MonoBehaviour
{
    protected bool _isAlive = true;

    public virtual void StartDying()
    {
        _isAlive = false;
    }
}
