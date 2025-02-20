using Player;
using UnityEngine;

namespace Interactables.Weapons
{
    public class Weapon : Interactable
    {
        public new Rigidbody rigidbody;
        private PlayerWeaponHolder _playerWeaponHolder;

        public void Start()
        {
            _playerWeaponHolder = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerWeaponHolder>();
        }

        protected override void Interact()
        {
            _playerWeaponHolder.Equip(this);
        }
    }
}