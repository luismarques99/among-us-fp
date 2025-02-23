using Player;
using UnityEngine;

namespace Interactables.Weapons
{
    public class Weapon : Interactable
    {
        public new Rigidbody rigidbody;
        public Vector3 normalScale;
        public Animator animator;

        [SerializeField] protected new Camera camera;
        [SerializeField] protected float damage;
        [SerializeField] protected float range;

        private PlayerWeaponHolder _playerWeaponHolder;

        public void Start()
        {
            camera = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerLook>().camera;
            _playerWeaponHolder = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerWeaponHolder>();
        }

        public virtual void Attack()
        {
        }

        protected override void Interact()
        {
            _playerWeaponHolder.Equip(this);
        }
    }
}