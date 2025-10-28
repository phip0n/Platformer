using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.Progress;

[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(Collider2D))]
public class Loot : MonoBehaviour
{
    private Animator _animator;
    private Collider2D _collider;
    private List<Item> _items;

    public bool IsActive { get; private set; } = true;

    private void Awake()
    {
        _items = new List<Item>();
        _animator = GetComponent<Animator>();
        _collider = GetComponent<Collider2D>();
        _collider.isTrigger = true;
    }

    public void AddItem(Item item)
    {
        _items.Add(item);
    }

    public void Interact(Player player)
    {
        IsActive = false;
        _collider.enabled = false;

        foreach (Item item in _items)
        {
            item.Interact(player);
        }

        _animator.SetTrigger(CoinAnimatorData.DisappearID);
    }

    private void Deactivate()
    {
        gameObject.SetActive(false);
    }
}