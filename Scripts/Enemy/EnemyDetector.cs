using UnityEngine;

public class EnemyDetector : MonoBehaviour
{
    [SerializeField] private float _radius = 5f;
    [SerializeField] private LayerMask _playerLayer;

    public Transform Target { get; private set; }

    private void FixedUpdate()
    {
        Collider2D player = Physics2D.OverlapCircle(transform.position, _radius, _playerLayer);

        if (player == null)
        {
            Target = null;
            return;
        }

        Target = player.transform;
    }
}