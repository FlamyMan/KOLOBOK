using UnityEngine;

[RequireComponent (typeof(Rigidbody2D), typeof(CircleCollider2D))]
public class Player_movement : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private float _jumpForce;

    private Rigidbody2D _rb;
    private CircleCollider2D _circleCollider;
    private Vector2 _lastMovementDirection = Vector2.zero;
    private DefaultControls _inputActions;

    private void Awake()
    {
        _inputActions = new DefaultControls();
        _circleCollider = GetComponent<CircleCollider2D>();
        _inputActions.Enable();
        _rb = GetComponent<Rigidbody2D>();
    }

    private void OnEnable()
    {
        _inputActions.Movement.Movement.started += Move;
        _inputActions.Movement.Movement.performed += Move;
        _inputActions.Movement.Movement.canceled += Move;
        _inputActions.Movement.Jump.started += Jump;
    }

    private void OnDisable()
    {
        _inputActions.Movement.Movement.started -= Move;
        _inputActions.Movement.Movement.performed -= Move;
        _inputActions.Movement.Movement.canceled -= Move;
        _inputActions.Movement.Jump.started -= Jump;
    }

    private void Jump(UnityEngine.InputSystem.InputAction.CallbackContext obj)
    {
        RaycastHit2D[] hit = new RaycastHit2D[2];
        _circleCollider.Raycast(Vector2.down, hit, distance: 1f, LayerMask.GetMask("Ground"));
        if (hit[0].distance <= _circleCollider.radius + 0.1f && hit[0].distance > 0)
        {
            _rb.AddForce(Vector2.up * _jumpForce, ForceMode2D.Impulse);
        }
    }

    private void Move(UnityEngine.InputSystem.InputAction.CallbackContext obj)
    {
        if(obj.started ||  obj.performed)
        {
            _lastMovementDirection.x = _speed * obj.ReadValue<Vector2>().x;
        }
        if (obj.canceled)
        {
            _lastMovementDirection = Vector2.zero;
        }
    }

    private void FixedUpdate()
    {
        _rb.AddForce(_lastMovementDirection);
    }
}
