using UnityEngine;

namespace Interactables.Weapons
{
    public class Pistol : Weapon
    {
        // public void Start()
        // {
        //     rigidbody = GetComponent<Rigidbody>();
        // }
        
        protected override void Interact()
        {
            base.Interact();
            gameObject.transform.localPosition = new Vector3(0.25f, -0.36f, 0.5f);
            gameObject.transform.localEulerAngles = new Vector3(0, 90, -5);
            rigidbody.isKinematic = true;
        }
    }
}