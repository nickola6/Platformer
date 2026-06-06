using System;
using UnityEngine;

public class CoinCounter : MonoBehaviour
{
    public event Action CountHasChanged;

    private Coin[] _coins;
    private int _countCoins;

    public int CountCoins => _countCoins;

    private void Start()
    {
        _coins = FindObjectsOfType<Coin>();

        foreach (Coin coin in _coins)
            coin.PickedUp += HandleCoinPickedUp;
    }

    private void OnDestroy()
    {
        foreach (Coin coin in _coins)
        {
            if (coin != null)
                coin.PickedUp -= HandleCoinPickedUp;
        }
    }

    private void HandleCoinPickedUp()
    {
        _countCoins++;
        CountHasChanged?.Invoke();
    }
}