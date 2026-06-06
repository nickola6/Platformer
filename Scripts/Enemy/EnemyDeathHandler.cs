using System.Collections;
using UnityEngine;

public class EnemyDeathHandler : MonoBehaviour
{
    [SerializeField] private Death _death;
    [SerializeField] private Collider2D _collider;
    [SerializeField] private int _deathSortingOrder = 3;

    private float _disableColliderDelay = 1f;
    private float _destroyDelay = 3f;
    private SpriteRenderer _spriteRenderer;

    private void OnEnable()
    {
        _death.Died += OnDied;
    }

    private void OnDisable()
    {
        _death.Died -= OnDied;
    }

    private void OnDied()
    {
        StartCoroutine(DeathRoutine());
        _spriteRenderer.sortingOrder = _deathSortingOrder;
    }

    private IEnumerator DeathRoutine()
    {
        yield return new WaitForSeconds(_disableColliderDelay);

        _collider.enabled = false;

        yield return new WaitForSeconds(_destroyDelay);

        Destroy(gameObject);
    }
}