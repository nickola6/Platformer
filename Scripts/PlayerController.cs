using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private Mover _mover;
    [SerializeField] private Jumper _jumper;
    [SerializeField] private InputReader _inputReader;
    [SerializeField] private GroundChecker _groundChecker;

    private void Update()
    {
        _mover.Move(_inputReader.Direction);

        if (_inputReader.IsJump == false)
            return;

        if (_groundChecker.IsGrounded)
            _jumper.Jump();

        _inputReader.ResetJump();
    }
}