using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Movement : MonoBehaviour
{
    private const float MinMoveSpeed = 0.01f;

    [SerializeField] private float _speed = 4f;
    [SerializeField] private float _jumpForce = 4f;

    private Rigidbody2D _rigidbody;
    private Vector3 _rightScale = Vector3.one;
    private Vector3 _leftScale = new Vector3(-1f, 1f, 1f);

    public bool IsMoving => Mathf.Abs(_rigidbody.velocity.x) > MinMoveSpeed;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    public void Move(float direction)
    {
        Vector2 velocity = _rigidbody.velocity;

        velocity.x = direction * _speed;

        _rigidbody.velocity = velocity;

        if (direction > 0f)
            transform.localScale = _rightScale;
        else if (direction < 0f)
            transform.localScale = _leftScale;
    }

    public void Jump()
    {
        Vector2 velocity = _rigidbody.velocity;
        velocity.y = _jumpForce;
        _rigidbody.velocity = velocity;
    }

    public Vector2 GetVelocity()
    {
        return _rigidbody.velocity;
    }
}