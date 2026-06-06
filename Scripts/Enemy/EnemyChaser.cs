using UnityEngine;

public class EnemyChaser : MonoBehaviour
{
    private const int StopValue = 0;
    private const float StopDistance = 0.3f;

    [SerializeField] private Mover _mover;

    public void Chase(Transform target)
    {
        float distance = target.position.x - transform.position.x;

        if (Mathf.Abs(distance) <= StopDistance)
        {
            _mover.Move(StopValue);
            return;
        }

        _mover.Move(Mathf.Sign(distance));
    }
}