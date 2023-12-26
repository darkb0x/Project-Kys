using ProjectKYS.Infrasturcture.Services.HUD;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

namespace ProjectKYS.Player.Controls.HUD
{
    public class InteractableHUDView : HUDElement<PlayerInteract>
    {
        [SerializeField] private TMP_Text _currentInteractableText;

        private PlayerInteract _playerInteract;

        public override void Assign(PlayerInteract input)
        {
            _playerInteract = input;

            SubscribeToEvents();
        }

        protected override void SubscribeToEvents()
        {
            base.SubscribeToEvents();

            _playerInteract.OnInteractableChanged += OnInteractableChanged;
        }

        protected override void UnsibscribeFromEvents()
        {
            base.UnsibscribeFromEvents();

            _playerInteract.OnInteractableChanged -= OnInteractableChanged;
        }

        private void OnInteractableChanged(Interactable interactable)
        {
            if (interactable == null)
                _currentInteractableText.gameObject.SetActive(false);
            else
            {
                _currentInteractableText.text = interactable.InteractableName;
                _currentInteractableText.gameObject.SetActive(true);
            }
        }
    }
}
