using Interactables.Weapons;
using UnityEngine;

namespace Player
{
    public class PlayerWeaponHolder : MonoBehaviour
    {
        public Transform weaponHolder;
        private InputManager _inputManager;

        public void Start()
        {
            _inputManager = GetComponent<InputManager>();
        }

        public void Update()
        {
            if (_inputManager.onFoot.WeaponDrop.triggered)
            {
                Drop();
            }
        }

        public void Equip(Weapon weapon)
        {
            if (weaponHolder.childCount > 0)
            {
                Drop();
            }

            weapon.gameObject.transform.SetParent(weaponHolder);
        }

        private void Drop()
        {
            if (weaponHolder.childCount == 0) return;
            weaponHolder.GetComponentInChildren<Weapon>().rigidbody.isKinematic = false;
            weaponHolder.DetachChildren();
        }
    }
}