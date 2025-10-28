using UnityEngine;

public class Coin : Item
{
    [SerializeField] private int _coinsNumber;

    public override void Interact(Player player)
    {
        player.TakeCoins(_coinsNumber);
    }
}
