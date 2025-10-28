using UnityEngine;

public class Healer : Item
{
    [SerializeField] private int _health = 30;

    public override void Interact(Player player)
    {
        player.Heal(_health);
    }
}
