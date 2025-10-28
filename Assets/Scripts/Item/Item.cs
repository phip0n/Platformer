using UnityEngine;

[RequireComponent (typeof(Loot))]
public abstract class Item : MonoBehaviour
{
    private void Awake()
    {
        Loot loot = GetComponent<Loot>();
        loot.AddItem(this);
    }

    public abstract void Interact(Player player);
}
