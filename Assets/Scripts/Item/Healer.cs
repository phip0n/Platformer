using UnityEngine;

public class Healer : Item
{
    [SerializeField] private int _health = 30;

    public int Health => _health;
}
