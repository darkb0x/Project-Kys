using ProjectKYS.Infrasturcture.Services.Input;
using System;
using System.Collections;
using UnityEngine;

namespace ProjectKYS.Player.Controls
{
    public class PlayerInteract : MonoBehaviour
    {
        [SerializeField] private Camera _camera;
        [SerializeField] private float _rayDistance;
        [SerializeField] private LayerMask _interactableLayers;

        public Action<Interactable> OnInteracted;

        private IInputService _inputService;
        private Interactable _currentInteractable;

        public void Initialize(IInputService inputService)
        {
            _inputService = inputService;

            _inputService.GetPlayerInputHandler().InteractEvent += Interact;
        }
        private void OnDestroy()
        {
            _inputService.GetPlayerInputHandler().InteractEvent -= Interact;
        }

        private void OnDrawGizmosSelected()
        {
            if (_camera == null)
                return;

            Gizmos.color = Color.green;
            Gizmos.DrawLine(_camera.transform.position, _camera.transform.position + _camera.transform.forward * _rayDistance);
        }


        private void Update()
        {
            RaycastHit hit;

            if (Physics.Raycast(new Ray(_camera.transform.position, _camera.transform.forward), out hit, _rayDistance, _interactableLayers))
            {
                if (hit.collider.TryGetComponent(out Interactable interactable))
                {
                    _currentInteractable = interactable.IsInteractable ? interactable : null;
                }
                else
                    _currentInteractable = null;
            }
            else
                _currentInteractable = null;
        }

        private void Interact()
        {
            _currentInteractable?.Interact();
            OnInteracted?.Invoke(_currentInteractable);
        }
    }
}