using UnityEngine;

[RequireComponent(typeof(Animator))]
public class PlayerAnimationController : MonoBehaviour
{
    private const string Speed = "Speed";
    private const string IsGrounded = "IsGrounded";

    [SerializeField] private InputReader _inputReader;
    [SerializeField] private GroundChecker _groundChecker;

    private Animator _animator;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
    }

    private void OnEnable()
    {
        _inputReader.DirectionChanged += OnDirectionChanged;
        _groundChecker.IsGroundedChanged += OnGroundedChanged;
    }

    private void OnDisable()
    {
        _inputReader.DirectionChanged -= OnDirectionChanged;
        _groundChecker.IsGroundedChanged -= OnGroundedChanged;
    }

    private void OnDirectionChanged(float direction)
    {
        _animator.SetFloat(Speed, Mathf.Abs(direction));
    }

    private void OnGroundedChanged(bool isGrounded)
    {
        _animator.SetBool(IsGrounded, isGrounded);
    }
}