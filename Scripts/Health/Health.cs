using System;
using UnityEngine;

public class Health : MonoBehaviour
{
    private const int MinValue = 0;

    [SerializeField] private float _maxValue = 100f;

    public event Action<float> ValueChanged;
    public event Action Died;

    private bool _isDead;

    public float CurrentValue { get; private set; }

    private void Awake()
    {
        CurrentValue = _maxValue;
    }

    public void TakeDamage(float damage)
    {
        if (_isDead)
            return;

        CurrentValue = Mathf.Max(MinValue, CurrentValue - damage);
        ValueChanged?.Invoke(CurrentValue);

        if (CurrentValue == MinValue)
        {
            _isDead = true;
            Died?.Invoke();
        }
    }

    public void Heal(float value)
    {
        CurrentValue = Mathf.Min(_maxValue, CurrentValue + value);
        ValueChanged?.Invoke(CurrentValue);
    }
}