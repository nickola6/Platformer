using UnityEngine;

public class GroundCheck : MonoBehaviour
{
    [SerializeField] private Transform _groundCheck;
    [SerializeField] private LayerMask _groundLayer;
    [SerializeField] private float _groundCheckRadius = 0.2f;

    public bool IsGrounded { get; private set; }

    private void Update()
    {
        IsGrounded = Physics2D.OverlapCircle(_groundCheck.position, _groundCheckRadius, _groundLayer) != null;
    }
}