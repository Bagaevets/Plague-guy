using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [Header("Movement Settings")]
    [SerializeField] private float _movementSpeed = 5f;
    [SerializeField] private Rigidbody2D _playerRigidbody;

    [SerializeField] private Animator _playerAnimator;

    private Vector2 _movementInput;
    private Vector2 _currentVelocity;


    void FixedUpdate()
    {
        HandleMovementInput();
        HandleRotation();
        ApplyMovement();
    }
    private void HandleMovementInput() 
    {
        _movementInput.x = Input.GetAxis("Horizontal");
        _movementInput.y = Input.GetAxis("Vertical");

        _playerAnimator.SetFloat("horizontal", Mathf.Abs(_movementInput.x));
        _playerAnimator.SetFloat("vertical", Mathf.Abs(_movementInput.y));
    }
    private void HandleRotation()
    {
        if (Mathf.Abs(_movementInput.x) > 0.1f)
        {
            float targetYRotation = _movementInput.x > 0 ? 0f : 180f;
            transform.rotation = Quaternion.Euler(0, targetYRotation, 0);
        }
    }
    private void ApplyMovement()
    { 
       _currentVelocity = _movementInput * _movementSpeed;
       _playerRigidbody.linearVelocity = _currentVelocity;
    }
}
