using System.Collections.Generic;
using UnityEngine;

public class PlayerDetector : MonoBehaviour
{

    private List<Player> _players = new List<Player>();

    public bool IsPlayerDetected { get; private set; }
    public Vector2 Target => new Vector2(_players[0].transform.position.x, _players[0].transform.position.y);

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out Player player))
        {
            IsPlayerDetected = true;
            _players.Add(player);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out Player player))
        {
            if (_players.Contains(player))
            {
                _players.Remove(player);

                if (_players.Count == 0)
                {
                    IsPlayerDetected = false;
                }
            }
        }
    }
}
