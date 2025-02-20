using TMPro;
using UnityEngine;

[RequireComponent(typeof(TextMeshProUGUI))]
public class CoinsCounter : MonoBehaviour
{
    [SerializeField] private CoinCatcher _coinCatcher;
    private TextMeshProUGUI _textMesh;

    private void Awake()
    {
        _textMesh= GetComponent<TextMeshProUGUI>();

        if (_coinCatcher != null)
        {
            _coinCatcher.TakedCoin += SetCounter;
        }
    }

    private void SetCounter(int value)
    {
        _textMesh.SetText(value.ToString());
    }
}
