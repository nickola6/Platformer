using UnityEngine;

[RequireComponent(typeof(Animator))]
public class PlayerAnimationController : MonoBehaviour
{
    private const string Speed = "Speed";
    private const string IsGrounded = "IsGrounded";

    [SerializeField] private Movement _movement;
    [SerializeField] private GroundCheck _groundCheck;

    private Animator _animator;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
    }

    private void Update()
    {
        float speed = Mathf.Abs(_movement.GetVelocity().x);
        bool isGrounded = _groundCheck.IsGrounded;

        _animator.SetFloat(Speed, speed);
        _animator.SetBool(IsGrounded, isGrounded);
    }
}