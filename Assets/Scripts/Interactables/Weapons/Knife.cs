using UnityEngine;

namespace Interactables.Weapons
{
    public class Knife : Weapon
    {
        public new void Start()
        {
            base.Start();
            normalScale = new Vector3(2f, 2f, 2f);
        }

        public override void Attack()
        {
            base.Attack();
            Debug.Log("Knife slice");
        }
        
        protected override void Interact()
        {
            base.Interact();
            gameObject.transform.localPosition = new Vector3(0.4f, -0.58f, 0.6f);
            gameObject.transform.localEulerAngles = new Vector3(5f, -117f, -6f);
            gameObject.transform.localScale = new Vector3(2f, 2.5f, 2.5f);
            rigidbody.isKinematic = true;
        }
    }
}