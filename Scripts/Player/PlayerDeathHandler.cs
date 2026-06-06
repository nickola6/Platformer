using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerDeathHandler : MonoBehaviour
{
    [SerializeField] private Death _death;
    [SerializeField] private Animator _animator;
    [SerializeField] private PlayerController _playerController;
    [SerializeField] private SpriteRenderer _spriteRenderer;
    [SerializeField] private Sprite _deathSprite;

    private float _restartDelay = 3f;

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
        _playerController.enabled = false;

        if (_animator != null)
            _animator.enabled = false;

        _spriteRenderer.sprite = _deathSprite;
        StartCoroutine(RestartSceneRoutine());
    }

    private IEnumerator RestartSceneRoutine()
    {
        yield return new WaitForSeconds(_restartDelay);

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}