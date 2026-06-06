using UnityEngine;

public class CollisionHandler : MonoBehaviour
{
    [SerializeField] private CoinCounter _coinCounter;
    [SerializeField] private Health _health;
    [SerializeField] private Death _death;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.TryGetComponent(out Coin coin))
        {
            _coinCounter.AddCoin();
            Destroy(coin.gameObject);

            return;
        }

        if (other.TryGetComponent(out Medkit medkit))
        {
            _health.Heal(medkit.HealValue);
            Destroy(medkit.gameObject);

            return;
        }

        if (other.TryGetComponent<Spikes>(out _))
        {
            _death.Die();

            return;
        }
    }
}