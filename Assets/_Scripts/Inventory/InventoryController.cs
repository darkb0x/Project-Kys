using ProjectKYS.Infrasturcture.Services.Input;
using ProjectKYS.Infrasturcture.Services.HUD;
using ProjectKYS.Player.Controls;
using UnityEngine;

namespace ProjectKYS.Inventory
{
    public class InventoryController : MonoBehaviour
    {
        public const int SLOTS_COUNT = 4;

        [SerializeField] private InventoryView _view;
        [SerializeField] private InventoryItemInspect _itemInspect;

        private IInputService _inputService;
        private PlayerInteract _playerInteract;
        private ItemComponent[] _itemSlots;
        private int _selectedSlot;

        public void Initialize(PlayerInteract playerInteract, IInputService inputService, IHUDService hudService)
        {
            _inputService = inputService;
            _playerInteract = playerInteract;

            _itemSlots = new ItemComponent[SLOTS_COUNT];
            _selectedSlot = 0;

            _view.Initialize(hudService);
            _view.UpdateView(_itemSlots, _selectedSlot);
            _itemInspect.Initialize(inputService);

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

        public bool UseItem(InventoryItem item)
        {
            if (_itemSlots[_selectedSlot] == null)
                return false;

            if (_itemSlots[_selectedSlot].Item == item)
            {
                return true;
            }

            return false;
        }
        public bool TakeItem(InventoryItem item)
        {
            if (UseItem(item))
            {
                Destroy(_itemSlots[_selectedSlot].gameObject);
                _itemSlots[_selectedSlot] = null;

                _view.UpdateView(_itemSlots, _selectedSlot);

                return true;
            }

            return false;
        }

        private void SetItemToSlot(int slot, ItemComponent item)
        {
            _itemSlots[slot] = item;

            item.IsInteractable = false;
            item.Rigidbody.isKinematic = true;
            _view.AddItem(item);

            _view.UpdateView(_itemSlots, _selectedSlot);
            _itemInspect.SetSelectedItem(_itemSlots[_selectedSlot]);
        }
        private void DropItemFromSlot(int slot)
        {
            var item = _itemSlots[slot];

            _view.RemoveItem(item);
            item.IsInteractable = true;
            item.Rigidbody.isKinematic = false;

            _itemSlots[slot] = null;

            _view.UpdateView(_itemSlots, _selectedSlot);
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

            _view.UpdateView(_itemSlots, _selectedSlot);
            _itemInspect.SetSelectedItem(_itemSlots[_selectedSlot]);

            //Debug.Log($"Selected slot: {_selectedSlot} '{_itemSlots[_selectedSlot]?.Item.Name}'");
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
