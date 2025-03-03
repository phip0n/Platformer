using UnityEngine;
using System;

[RequireComponent(typeof(Collider2D))]
public class CoinCatcher : MonoBehaviour
{
    private int _coinsCollected = 0;

    public event Action<int> TakedCoin;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent(out Coin coin) && coin.IsActive)
        {
            coin.Interact();
            _coinsCollected++;
            TakedCoin?.Invoke(_coinsCollected);
        }
    }
}