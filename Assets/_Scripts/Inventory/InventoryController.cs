using ProjectKYS.Infrasturcture.Services.Input;
using ProjectKYS.Player.Controls;
using UnityEngine;

namespace ProjectKYS.Inventory
{
    public class InventoryController : MonoBehaviour
    {
        private const int SLOTS_COUNT = 4;

        [SerializeField] private InventoryView _view;

        private IInputService _inputService;
        private PlayerInteract _playerInteract;
        private ItemComponent[] _itemSlots;
        private int _selectedSlot;

        public void Initialize(PlayerInteract playerInteract, IInputService inputService)
        {
            _inputService = inputService;
            _playerInteract = playerInteract;

            _itemSlots = new ItemComponent[SLOTS_COUNT];

            _inputService.GetPlayerInputHandler().SelectItemEvent += OnSelectSlot;
            _inputService.GetPlayerInputHandler().DropItemEvent += OnDropItem;
            _playerInteract.OnInteracted += OnTryingTakeItem;

        }
        private void OnDestroy()
        {
            _inputService.GetPlayerInputHandler().SelectItemEvent -= OnSelectSlot;
            _inputService.GetPlayerInputHandler().DropItemEvent -= OnDropItem;
            _playerInteract.OnInteracted -= OnTryingTakeItem;
        }

        private void SetItemToSlot(int slot, ItemComponent item)
        {
            _itemSlots[slot] = item;

            item.IsInteractable = false;
            item.Rigidbody.isKinematic = true;
            _view.AddItem(item);
        }
        private void DropItemFromSlot(int slot)
        {
            var item = _itemSlots[slot];

            _view.RemoveItem(item);
            item.IsInteractable = true;
            item.Rigidbody.isKinematic = false;

            _itemSlots[slot] = null;
        }

        private bool IsSelectedSlotFree()
            => _itemSlots[_selectedSlot] == null;

        private void OnSelectSlot(int delta)
        {
            if (_selectedSlot + delta < 0)
                _selectedSlot = SLOTS_COUNT - 1;
            else if (_selectedSlot + delta >= SLOTS_COUNT)
                _selectedSlot = 0;
            else
                _selectedSlot += delta;

            _view.SetItemActive(_itemSlots, _selectedSlot);

            Debug.Log($"Selected slot: {_selectedSlot} '{_itemSlots[_selectedSlot]?.Item.Name}'");
        }
        private void OnDropItem()
        {
            if (IsSelectedSlotFree())
                return;

            DropItemFromSlot(_selectedSlot);
        }
        private void OnTryingTakeItem(Interactable interactable)
        {
            if(interactable is ItemComponent item)
            {
                if (!IsSelectedSlotFree())
                    DropItemFromSlot(_selectedSlot);

                SetItemToSlot(_selectedSlot, item);
            }
        }
    }
}
