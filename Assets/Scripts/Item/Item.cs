using UnityEngine;

public class Item : MonoBehaviour
{
    private Animator _animator;
    private Collider2D _collider;

    public bool IsActive { get; private set; } = true;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
        _collider = GetComponent<Collider2D>();
        _collider.isTrigger = true;
    }

    public void Interact()
    {
        IsActive = false;
        _collider.enabled = false;
        _animator.SetTrigger(CoinAnimatorData.DisappearID);
    }

    private void Deactivate()
    {
        gameObject.SetActive(false);
    }
}
