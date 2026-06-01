using TMPro;
using UnityEngine;

public class CoinCounterView : MonoBehaviour
{
    [SerializeField] private CoinCounter _coinCounter;
    [SerializeField] private TextMeshProUGUI _text;

    private void Start()
    {
        UpdateDisplay();
    }

    private void OnEnable()
    {
        _coinCounter.CountHasChanged += UpdateDisplay;
    }

    private void OnDisable()
    {
        _coinCounter.CountHasChanged -= UpdateDisplay;
    }

    private void UpdateDisplay()
    {
        _text.text = _coinCounter.CountCoins.ToString();
    }
}