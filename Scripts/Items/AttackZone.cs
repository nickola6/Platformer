using System.Collections;
using UnityEngine;

public class AttackZone : MonoBehaviour
{
    [SerializeField] private LayerMask _targetLayer;
    [SerializeField] private Attacker _attacker;
    [SerializeField] private float _attackDelay = 1f;

    private Health _healthEnemy;
    private Coroutine _coroutine;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.TryGetComponent(out Health health))
        {
            _healthEnemy = health;

            if (_coroutine == null)
            {
                _coroutine = StartCoroutine(AttackRoutine());
            }
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.TryGetComponent(out Health health) && health == _healthEnemy)
        {
            _healthEnemy = null;

            if (_coroutine != null)
            {
                StopCoroutine(_coroutine);
                _coroutine = null;
            }
        }
    }

    private IEnumerator AttackRoutine()
    {
        WaitForSeconds wait = new WaitForSeconds(_attackDelay);

        while (_healthEnemy != null)
        {
            _attacker.Attack(_healthEnemy);

            yield return wait;
        }

        _coroutine = null;
    }
}