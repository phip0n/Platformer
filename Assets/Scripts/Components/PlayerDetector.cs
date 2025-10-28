using System.Collections;
using UnityEngine;

public class PlayerDetector : MonoBehaviour
{
    [SerializeField] private EnemyMover _enemy;
    [SerializeField] private float _cooldown = 5;
    [SerializeField] private float _range = 10;
    [SerializeField] private int _playerLayer = 5;

    private WaitForSeconds _cooldownTime;

    private void Awake()
    {
        _cooldownTime = new WaitForSeconds(_cooldown);
        //StartCoroutine(Detect());
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out Player player))
        {
            _enemy.StartChase(player.transform);
            //TryFindPlayer();
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out Player player))
        {
            _enemy.StopChase();
        }
    }

    /*private void TryFindPlayer()
    {
        Collider2D[] player = Physics2D.OverlapCircleAll(transform.position, _range, _playerLayer);

        if (player != null)
        {
            _enemy.StartChase(player[0].transform);
        }
        else
        {
            _enemy.StopChase();
        }

        Debug.Log(player);
    }

    private IEnumerator Detect()
    {
        yield return _cooldownTime;
        
        TryFindPlayer();
    }*/
}
