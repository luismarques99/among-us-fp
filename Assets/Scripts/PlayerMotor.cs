using System;
using UnityEngine;

public class PlayerMotor : MonoBehaviour
{
    public float speed = 5f;
    public float gravity = -9.81f;
    public float jumpHeight = 3f;
    private CharacterController _character;
    private Vector3 _playerVelocity;
    private bool _isGrounded;

    public void Start()
    {
        _character = GetComponent<CharacterController>();
    }

    public void Update()
    {
        _isGrounded = _character.isGrounded;
    }

    /**
     * <summary>
     * Receives the inputs from our <c>InputManager.cs</c> and applies them to our character controller.
     * </summary>
     * <param name="input">Input from <c>InputManager.cs</c></param>
     */
    public void ProcessMove(Vector2 input)
    {
        var moveDirection = Vector3.zero;
        moveDirection.x = input.x;
        moveDirection.z = input.y;
        _character.Move(transform.TransformDirection(moveDirection) * (speed * Time.deltaTime));
        _playerVelocity.y += gravity * Time.deltaTime;
        if (_isGrounded && _playerVelocity.y < 0)
        {
            _playerVelocity.y = -2f;
        }
        _character.Move(_playerVelocity * Time.deltaTime);
    }

    public void Jump()
    {
        if (!_isGrounded) return;
        // _playerVelocity.y = Mathf.Sqrt(jumpHeight * -3f * gravity);
        _playerVelocity.y = jumpHeight;
    }
}