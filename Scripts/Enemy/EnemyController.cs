using UnityEngine;

public class EnemyController : MonoBehaviour
{
    [SerializeField] private EnemyDetector _enemyDetector;
    [SerializeField] private EnemyPatrolController _enemyPatrolController;
    [SerializeField] private EnemyChaser _enemyChaser;

    private void FixedUpdate()
    {
        if (_enemyDetector.Target != null)
            _enemyChaser.Chase(_enemyDetector.Target);
        else
            _enemyPatrolController.Patrol();
    }
}