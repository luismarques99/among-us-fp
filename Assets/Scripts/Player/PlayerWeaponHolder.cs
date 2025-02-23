using Interactables.Weapons;
using UnityEngine;

namespace Player
{
    public class PlayerWeaponHolder : MonoBehaviour
    {
        [SerializeField] private Transform weaponHolder;
        private InputManager _inputManager;
        private Weapon _equippedWeapon;

        public void Start()
        {
            _inputManager = GetComponent<InputManager>();
        }

        public void Update()
        {
            if (_inputManager.OnFoot.WeaponDrop.triggered)
            {
                Drop();
            }

            if (_inputManager.OnFoot.Attack.triggered && _equippedWeapon)
            {
                _equippedWeapon.Attack();
            }
        }

        public void Equip(Weapon weapon)
        {
            if (_equippedWeapon)
            {
                Drop();
            }

            weapon.gameObject.transform.SetParent(weaponHolder);
            _equippedWeapon = weapon;
        }

        private void Drop()
        {
            if (!_equippedWeapon) return;
            _equippedWeapon.rigidbody.isKinematic = false;
            _equippedWeapon.animator.enabled = false;
            _equippedWeapon.transform.localScale = _equippedWeapon.normalScale;
            weaponHolder.DetachChildren();
        }
    }
}