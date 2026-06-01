using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private Movement _movement;
    [SerializeField] private InputReader _inputReader;
    [SerializeField] private GroundCheck _groundCheck;

    private void Update()
    {
        _movement.Move(_inputReader.Direction);

        if (_inputReader.IsJump == false)
            return;

        if (_groundCheck.IsGrounded)
            _movement.Jump();

        _inputReader.ResetJump();
    }
}