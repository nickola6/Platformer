using System;
using UnityEngine;

public class Coin : MonoBehaviour
{
    public static event Action PickedUp;

    public static void Collect()
    {
        PickedUp?.Invoke();
    }
}