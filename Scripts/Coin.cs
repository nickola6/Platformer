using System;
using UnityEngine;

public class Coin : MonoBehaviour
{
    public static event Action PickedUp;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.TryGetComponent<PlayerController>(out _) == false)
            return;

        Destroy(gameObject);
        PickedUp?.Invoke();
    }
}