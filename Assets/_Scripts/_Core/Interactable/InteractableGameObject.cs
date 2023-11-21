using System.Collections;
using UnityEngine;
using UnityEngine.Events;

namespace ProjectKYS
{
    public class InteractableGameObject : Interactable
    {
        [SerializeField] private string _interactableName;
        [SerializeField] private UnityEvent _interactEvent;

        public override string InteractableName => _interactableName;

        public override void Interact()
        {
            _interactEvent?.Invoke();
            base.Interact();
        }
    }
}