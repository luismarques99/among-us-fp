using UnityEngine;

namespace Player
{
    public class PlayerLook : MonoBehaviour
    {
        public new Camera camera;
        [SerializeField] private float sensitivity = 20f;
        private float _xRotation = 0f;

        public void Start()
        {
            Cursor.visible = false;
            Cursor.lockState = CursorLockMode.Confined;
        }

        /**
         * <summary>
         * Processes the look of the player. It receives the inputs from our <c>InputManager.cs</c> and applies them to our character controller.
         * </summary>
         * <param name="input">Input from <c>InputManager.cs</c></param>
         */
        public void ProcessLook(Vector2 input)
        {
            var mouseX = input.x;
            var mouseY = input.y;
            // Calculate camera rotation for looking up and down
            _xRotation -= mouseY * Time.deltaTime * sensitivity;
            _xRotation = Mathf.Clamp(_xRotation, -90f, 90f);
            // Apply this to our camera transform
            camera.transform.localRotation = Quaternion.Euler(_xRotation, 0f, 0f);
            // Rotate player to look left and right
            transform.Rotate(Vector3.up * (mouseX * Time.deltaTime) * sensitivity);
        }
    }
}