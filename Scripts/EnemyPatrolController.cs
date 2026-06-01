using UnityEngine;

public class EnemyPatrolController : MonoBehaviour
{
    private const float RightDirection = 1f;
    private const float LeftDirection = -1f;

    [SerializeField] private Movement _movement;
    [SerializeField] private Transform _leftPoint;
    [SerializeField] private Transform _rightPoint;

    [SerializeField] private float _arrivalDistance = 0.2f;

    private Transform _target;

    private void Start()
    {
        _target = _rightPoint;
    }

    private void Update()
    {
        float distance = Mathf.Abs(_target.position.x - transform.position.x);

        if (distance <= _arrivalDistance)
        {
            ChangeTarget();
            return;
        }

        float moveDirection = GetMoveDirection();

        _movement.Move(moveDirection);
    }

    private float GetMoveDirection()
    {
        if (_target.position.x > transform.position.x)
            return RightDirection;

        return LeftDirection;
    }
    
    private void ChangeTarget()
    {
        if (_target == _rightPoint)
            _target = _leftPoint;
        else
            _target = _rightPoint;
    }
}