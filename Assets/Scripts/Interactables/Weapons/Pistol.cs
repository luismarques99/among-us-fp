using Player;
using UnityEngine;

namespace Interactables.Weapons
{
    public class Pistol : Weapon
    {
        // [SerializeField] private GameObject bulletPrefab;
        // [SerializeField] private GameObject bulletShotPosition;
        // [SerializeField] private GameObject bulletCaseThrownPosition;
        // [SerializeField] private float bulletSpeed = 1000;
        // [SerializeField] private float bulletGravity = 50;
        
        [SerializeField] private ParticleSystem muzzleFlash;
        [SerializeField] private AudioSource audioSource;

        public new void Start()
        {
            base.Start();
            animator = GetComponent<Animator>();
            normalScale = new Vector3(2.5f, 2.5f, 2.5f);
            damage = 100f;
            range = 50f;
        }

        public override void Attack()
        {
            base.Attack();
            // Old way
            // var bullet = bulletPrefab.transform.GetChild(0).gameObject;
            // // bullet.transform.localScale = new Vector3(2.5f, 2.5f, 2.5f);
            // var bulletShot = Instantiate(bullet, bulletShotPosition.transform.position, bulletShotPosition.transform.rotation);
            // var bulletRigidbody = bulletShot.GetComponent<Rigidbody>();
            // bulletRigidbody.AddForce(-transform.right * bulletSpeed);
            // // bulletRigidbody.AddForce(-transform.up * bulletGravity, ForceMode.Acceleration);
            // Destroy(bulletShot, 1f);

            // New way
            audioSource.Play();
            muzzleFlash.Play();
            // animator.enabled = true;
            animator.Play("Shoot");
            // animator.Play("Idle");
            // animator.enabled = false;
            if (Physics.Raycast(camera.transform.position, camera.transform.forward, out var hitInfo, range))
            {
                Debug.Log(hitInfo.transform.name);
            }
        }

        protected override void Interact()
        {
            base.Interact();
            gameObject.transform.localPosition = new Vector3(0.3f, -0.41f, 0.4f);
            gameObject.transform.localEulerAngles = new Vector3(0f, 87f, -5f);
            gameObject.transform.localScale = new Vector3(2.4f, 3f, 3f);
            rigidbody.isKinematic = true;
            animator.enabled = true;
        }

        private void Awake()
        {
            audioSource = GetComponent<AudioSource>();
        }
    }
}