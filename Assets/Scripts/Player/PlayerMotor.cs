using UnityEngine;

namespace Player
{
    public class PlayerMotor : MonoBehaviour
    {
        public float gravity = -9.81f;
        public float jumpHeight = 3f;
        public float currentSpeed = 5f;
        public float normalSpeed = 5f;
        public float sprintSpeed = 10f;
        private CharacterController _character;
        private Vector3 _playerVelocity;

        private bool _isGrounded;
        // Sprint and crouch disabled
        // private bool _isSprinting;
        // private bool _isCrouching;
        // private bool _lerpCrouch;
        // private float _crouchTimer;

        public void Start()
        {
            _character = GetComponent<CharacterController>();
            // Sprint and crouch disabled
            // _isSprinting = false;
            // _lerpCrouch = false;
            // _crouchTimer = 0f;
        }

        public void Update()
        {
            _isGrounded = _character.isGrounded;
            // Crouch disabled
            // var interpolation = _crouchTimer * _crouchTimer;
            // if (_lerpCrouch)
            // {
            //     _crouchTimer += Time.deltaTime;
            //     _character.height = Mathf.Lerp(_character.height, _isCrouching ? 1 : 2, interpolation);
            //     if (interpolation > 1)
            //     {
            //         _lerpCrouch = false;
            //         _crouchTimer = 0f;
            //     }
            // }
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
            _character.Move(transform.TransformDirection(moveDirection) * (currentSpeed * Time.deltaTime));
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

        // Sprint and crouch disabled
        // public void Sprint()
        // {
        //     _isSprinting = !_isSprinting;
        //     currentSpeed = _isSprinting ? sprintSpeed : normalSpeed;
        // }
        //
        // public void Crouch()
        // {
        //     _isCrouching = !_isCrouching;
        //     _crouchTimer = 0;
        //     _lerpCrouch = true;
        // }
    }
}