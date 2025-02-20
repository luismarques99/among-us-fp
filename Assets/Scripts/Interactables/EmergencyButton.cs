using UnityEngine;

namespace Interactables
{
    public class EmergencyButton : Interactable
    {
        // Overriden implementation of Interact method.
        protected override void Interact()
        {
            Debug.Log("Pressed emergency button");
        }
    }
}
