using UnityEngine;

namespace Player
{
    public class PlayerInteract : MonoBehaviour
    {
        [SerializeField] private float distance = 1.5f;
        [SerializeField] private LayerMask mask;
        private Camera _camera;
        private PlayerUI _playerUI;
        private InputManager _inputManager;

        public void Start()
        {
            _camera = GetComponent<PlayerLook>().camera;
            _playerUI = GetComponent<PlayerUI>();
            _inputManager = GetComponent<InputManager>();
        }

        public void Update()
        {
            _playerUI.UpdateText(string.Empty);
            // Creates a ray at the center of the camera pointing forward.
            var ray = new Ray(_camera.transform.position, _camera.transform.forward);
            Debug.DrawRay(ray.origin, ray.direction * distance, Color.red);
            RaycastHit hitInfo; // Stores our collision information.
            if (Physics.Raycast(ray, out hitInfo, distance, mask))
            {
                var interactable = hitInfo.collider.GetComponent<Interactable>();
                if (interactable)
                {
                    _playerUI.UpdateText(interactable.promptMessage);
                    if (_inputManager.onFoot.Interact.triggered)
                    {
                        interactable.BaseInteract();
                    }
                }
            }
        }
    }
}