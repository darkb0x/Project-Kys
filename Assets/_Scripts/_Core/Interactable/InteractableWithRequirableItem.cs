using ProjectKYS.Inventory;
using System.Collections;
using UnityEngine;
using UnityEngine.Events;

namespace ProjectKYS
{
    public class InteractableWithRequirableItem : Interactable
    {
        public enum ItemUseType { Take, Use }

        [SerializeField] private string _interactableName;
        [Space]
        [SerializeField] private InventoryItem _requiredItem;
        [SerializeField] private ItemUseType _useType = ItemUseType.Take;
        [SerializeField] private bool _deactivateAfterUsage = true;
        [Space]
        [SerializeField] private UnityEvent _onActivated;

        public override string InteractableName => GetShowedText();

        private bool _used;

        private void Awake()
        {
            _used = false;
        }

        public override void Interact()
        {
            _onActivated?.Invoke();
            _used = true;

            if (_deactivateAfterUsage)
                IsInteractable = false;

            base.Interact();
        }

        public void Interact(InventoryController inventory)
        {
            if(_used)
            {
                Interact();
                return;
            }

            if (_useType == ItemUseType.Take)
                TakeItem(inventory);
            else if (_useType == ItemUseType.Use)
                UseItem(inventory);
        }

        private void TakeItem(InventoryController inventory)
        {
            if(inventory.TakeItem(_requiredItem))
                Interact();
        }
        private void UseItem(InventoryController inventory)
        {
            if (inventory.UseItem(_requiredItem))
                Interact();
        }

        private string GetShowedText()
        {
            if(_used)
            {
                return _interactableName;
            }
            else
            {
                return $"{_interactableName}\nRequired: {_requiredItem.Name}";
            }
        }
    }
}