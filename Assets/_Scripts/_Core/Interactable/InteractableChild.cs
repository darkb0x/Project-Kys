using System.Collections;
using UnityEngine;

namespace ProjectKYS
{
    public class InteractableChild : Interactable
    {
        [SerializeField] private Interactable _parent;

        public override string InteractableName { get => _parent.InteractableName; }

        public override void Interact()
            => _parent.Interact();
    }
}