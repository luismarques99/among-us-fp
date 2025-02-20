using UnityEngine;

namespace Interactables.Weapons
{
    public class Knife : Weapon
    {
        protected override void Interact()
        {
            base.Interact();
            gameObject.transform.localPosition = new Vector3(0.3f, -0.45f, 0.6f);
            gameObject.transform.localEulerAngles = new Vector3(0, -110, -5);
            rigidbody.isKinematic = true;
        }
    }
}