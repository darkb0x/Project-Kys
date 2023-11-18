using UnityEngine;

namespace ProjectKYS
{
    public abstract class Interactable : MonoBehaviour
    {
        public bool IsInteractable = true;
        public abstract string InteractableName { get; }

        public abstract void Interact();
    }
}
