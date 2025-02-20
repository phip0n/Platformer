using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Collider2D))]
public class CoinCatcher : MonoBehaviour
{
    private int _coinsCollected = 0;

    public event UnityAction<int> TakedCoin;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent(out Coin coin) && coin.IsActive)
        {
            coin.InteractWithPlayer();
            _coinsCollected++;
            TakedCoin?.Invoke(_coinsCollected);
        }
    }
}
