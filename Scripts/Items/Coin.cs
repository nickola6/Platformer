using System;
using UnityEngine;

public class Coin : MonoBehaviour
{
    public event Action PickedUp;

    public void Collect()
    {
        PickedUp?.Invoke();
    }
}