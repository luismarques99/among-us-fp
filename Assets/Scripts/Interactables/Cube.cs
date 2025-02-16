using UnityEngine;

namespace Interactables
{
    public class Cube : Interactable
    {
        // Overriden implementation of Interact method.
        protected override void Interact()
        {
            Debug.Log("Cube grabbed");
        }
    }
}