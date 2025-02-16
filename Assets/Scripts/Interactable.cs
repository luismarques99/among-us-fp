using UnityEngine;

public abstract class Interactable : MonoBehaviour
{
    /**
     * Message displayed to player when looking at an interactable object.
     */
    public string promptMessage;

    public void BaseInteract()
    {
        Interact();
    }

    protected virtual void Interact()
    {
        // Empty method as this is a template to be overridden by subclasses.
    }
}