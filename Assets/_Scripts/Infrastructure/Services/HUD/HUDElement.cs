using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ProjectKYS.Infrasturcture.Services.HUD
{
    public abstract class HUDElement : MonoBehaviour
    {
        protected IHUDService _hudService;
        protected bool _isInitialized;

        public virtual void Initialize(IHUDService service) 
        {
            _hudService = service;
            _isInitialized = true;
        }
        private void OnDestroy()
        {
            if (_isInitialized)
                UnsibscribeFromEvents();
        }

        public virtual void Show()
        {
            gameObject.SetActive(true);
        }
        public virtual void Hide()
        {
            gameObject.SetActive(false);
        }

        protected virtual void SubscribeToEvents() { }
        protected virtual void UnsibscribeFromEvents() { }
    }
    public abstract class HUDElement<T> : HUDElement
    {
        public abstract void Assign(T input);
    }
}
