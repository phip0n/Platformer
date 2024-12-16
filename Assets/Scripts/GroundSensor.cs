using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public class GroundSensor : MonoBehaviour
{
    private int _collaidersCount = 0;

    public bool isOnGraund => _collaidersCount > 0;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.isTrigger == false)
        {
            _collaidersCount++;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.isTrigger == false)
        {
            _collaidersCount--;
        }
    }
}
