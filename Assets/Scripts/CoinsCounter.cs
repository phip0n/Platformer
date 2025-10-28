using TMPro;
using UnityEngine;

[RequireComponent(typeof(TextMeshProUGUI))]
public class CoinsCounter : MonoBehaviour
{
    [SerializeField] private Wallet _wallet;
    private TextMeshProUGUI _textMesh;

    private void Awake()
    {
        _textMesh= GetComponent<TextMeshProUGUI>();
    }

    private void OnEnable()
    {
        if (_wallet != null)
        {
            _wallet.TakedCoins += SetCounter;
        }
    }

    private void OnDisable()
    {
        _wallet.TakedCoins -= SetCounter;
    }

    private void SetCounter(int value)
    {
        _textMesh.SetText(value.ToString());
    }
}
