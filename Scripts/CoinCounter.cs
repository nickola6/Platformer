using System;
using UnityEngine;

public class CoinCounter : MonoBehaviour
{
    public event Action CountHasChanged;

    private int _countCoins = 0;

    public int CountCoins => _countCoins;

    private void OnEnable()
    {
        Coin.PickedUp += HandleCoinPickedUp;
    }

    private void OnDisable()
    {
        Coin.PickedUp -= HandleCoinPickedUp;
    }

    private void HandleCoinPickedUp()
    {
        _countCoins++;
        CountHasChanged?.Invoke();
    }
}