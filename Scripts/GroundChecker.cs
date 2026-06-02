using System;
using UnityEngine;

public class GroundChecker : MonoBehaviour
{
    [SerializeField] private Transform _groundCheck;
    [SerializeField] private LayerMask _groundLayer;
    [SerializeField] private float _groundCheckRadius = 0.2f;

    public event Action<bool> IsGroundedChanged;

    public bool IsGrounded { get; private set; }

    private void Update()
    {
        bool isGrounded = Physics2D.OverlapCircle(_groundCheck.position, _groundCheckRadius, _groundLayer) != null;

        if (isGrounded == IsGrounded)
            return;

        IsGrounded = isGrounded;
        IsGroundedChanged?.Invoke(IsGrounded);
    }
}