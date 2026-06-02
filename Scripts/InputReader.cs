using UnityEngine;

public class InputReader : MonoBehaviour
{
    private const string Horizontal = "Horizontal";
    private const KeyCode JumpKey = KeyCode.Space;

    public event Action<float> DirectionChanged;
    public float Direction { get; private set; }
    public bool IsJump { get; private set; }

    private void Update()
    {
        Direction = Input.GetAxisRaw(Horizontal);
        DirectionChanged?.Invoke(Direction);
        IsJump = Input.GetKeyDown(JumpKey);
    }

    public void ResetJump()
    {
        IsJump = false;
    }
}