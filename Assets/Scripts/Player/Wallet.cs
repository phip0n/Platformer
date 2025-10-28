using System;
using UnityEngine;

public class Wallet : MonoBehaviour
{
    private int _coins = 0;

    public event Action<int> TakedCoins;

    public void TakeCoins(int coins)
    {
        _coins += coins;
        TakedCoins?.Invoke(_coins);
    }
}
