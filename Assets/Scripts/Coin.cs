using UnityEngine;

[RequireComponent(typeof(Collider2D))]
[RequireComponent (typeof(Animator))]
public class Coin : MonoBehaviour
{
    private const string Disappear = nameof(Disappear);

    [SerializeField] private float _disappearTime;

    public bool IsActive { get; private set; } = true;
    private Animator _animator;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
        Collider2D collider = GetComponent<Collider2D>();
        collider.isTrigger = true;
    }

    public void InteractWithPlayer()
    {
        IsActive = false;
        GetComponent<Collider2D>().enabled = false;
        _animator.SetTrigger(Disappear);
    }

    private void Deactivate()
    {
        gameObject.SetActive(false);
    }
}
