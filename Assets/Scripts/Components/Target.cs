using UnityEngine;

[RequireComponent (typeof(Health))]
public class Target : MonoBehaviour
{
    [SerializeField] private int _teamID = 0;

    private Health _health;

    public int TeamID => _teamID;

    private void Awake()
    {
        _health = GetComponent<Health>();
    }

    public void TakeDamage(int points)
    {
        _health.TakeDamage(points);
    }
}
