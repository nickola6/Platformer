using System;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Death : MonoBehaviour
{
    [SerializeField] private Health _health;
    [SerializeField] private float _deathJumpForce = 3f;

    public event Action Died;

    private Rigidbody2D _rigidbody;
    private bool _isDead;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    private void OnEnable()
    {
        _health.Died += Die;
    }

    private void OnDisable()
    {
        _health.Died -= Die;
    }

    public void Die()
    {
        if (_isDead)
            return;

        _isDead = true;

        _rigidbody.velocity = Vector2.zero;
        _rigidbody.AddForce(Vector2.up * _deathJumpForce, ForceMode2D.Impulse);

        Died?.Invoke();
    }
}