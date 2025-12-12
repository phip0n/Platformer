using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public class GroundSensor : MonoBehaviour
{
    private int _collaidersCount = 0;

    public bool IsOnGround => _collaidersCount > 0;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent<Ground>(out _))
        {
            _collaidersCount++;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.GetComponent<Ground>())
        {
            _collaidersCount--;
        }
    }
}
