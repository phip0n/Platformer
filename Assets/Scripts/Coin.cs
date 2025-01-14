using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider2D))]
[RequireComponent (typeof(Animator))]
public class Coin : MonoBehaviour
{
    private const string Disappear = nameof(Disappear);

    [SerializeField] private float _disappearTime;

    private Animator _animator;
    private bool _isActive;

    private void Awake()
    {
        _isActive = true;
        _animator = GetComponent<Animator>();
        Collider2D collider = GetComponent<Collider2D>();
        collider.isTrigger = true;
    }

    public void InteractWithPlayer()
    {
        if( _isActive )
        {
            _isActive = false;
            _animator.SetTrigger(Disappear);
        }
    }

    private void Deactivate()
    {
        gameObject.SetActive(false);
    }
}
