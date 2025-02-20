using Interactables;
using UnityEngine;

namespace Player
{
    public class PlayerInteract : MonoBehaviour
    {
        [SerializeField] private float distance = 1.5f;
        [SerializeField] private LayerMask mask;
        private Camera _camera;
        private PlayerHUD _playerHUD;
        private InputManager _inputManager;

        public void Start()
        {
            _camera = GetComponent<PlayerLook>().camera;
            _playerHUD = GetComponent<PlayerHUD>();
            _inputManager = GetComponent<InputManager>();
        }

        public void Update()
        {
            _playerHUD.UpdateText(string.Empty);
            // Creates a ray at the center of the camera pointing forward.
            var ray = new Ray(_camera.transform.position, _camera.transform.forward);
            Debug.DrawRay(ray.origin, ray.direction * distance, Color.red);
            // RaycastHit hitInfo; // Stores our collision information.
            if (Physics.Raycast(ray, out var hitInfo, distance, mask))
            {
                var interactable = hitInfo.collider.GetComponent<Interactable>();
                if (!interactable) interactable = hitInfo.collider.transform.root.GetComponent<Interactable>();
                if (!interactable) return;
                _playerHUD.UpdateText(interactable.promptMessage);
                if (_inputManager.onFoot.Interact.triggered)
                {
                    interactable.BaseInteract();
                }
            }
        }
    }
}