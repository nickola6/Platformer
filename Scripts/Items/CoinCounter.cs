using System;
using UnityEngine;

public class CoinCounter : MonoBehaviour
{
    public event Action CountHasChanged;

    private int _countCoins;

    public int CountCoins => _countCoins;

    public void AddCoin()
    {
        _countCoins++;
        CountHasChanged?.Invoke();
    }
}