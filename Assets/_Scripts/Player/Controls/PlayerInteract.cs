using ProjectKYS.Infrasturcture.Services.HUD;
using ProjectKYS.Infrasturcture.Services.Input;
using ProjectKYS.Inventory;
using ProjectKYS.Player.Controls.HUD;
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

        public Action<Interactable> OnInteractableChanged;
        public Action<Interactable> OnInteracted;

        private IInputService _inputService;
        private InventoryController _inventoryController;
        private InteractableHUDView _hudView;
        private Interactable m_currentInteractable;
        private Interactable _currentInteractable
        {
            get => m_currentInteractable;
            set
            {
                m_currentInteractable = value;
                OnInteractableChanged?.Invoke(m_currentInteractable);
            }
        }

        public void Initialize(InventoryController inventory, IInputService inputService, IHUDService hudService)
        {
            _inputService = inputService;
            _inventoryController = inventory;

            _hudView = hudService.GetHudElement<InteractableHUDView>();
            _hudView.Assign(this);

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
            if (_currentInteractable == null)
                return;

            if (_currentInteractable is InteractableWithRequirableItem interactableWithRequirableItem)
                interactableWithRequirableItem.Interact(_inventoryController);
            else
                _currentInteractable.Interact();

            OnInteracted?.Invoke(_currentInteractable);
        }
    }
}