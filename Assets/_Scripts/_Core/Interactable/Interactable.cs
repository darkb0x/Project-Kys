using System;
using UnityEngine;

namespace ProjectKYS
{
    public abstract class Interactable : MonoBehaviour, ISceneLoadActivator
    {
        public bool IsInteractable = true;
        public abstract string InteractableName { get; }
        public Action OnActivateScene { get => OnInteracted; set => OnInteracted = value; }

        public Action OnInteracted;

        public virtual void Interact()
        {
            OnInteracted?.Invoke();
        }
    }
}
