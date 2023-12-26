using ProjectKYS.Infrasturcture.Services.HUD;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ProjectKYS.Inventory.HUD
{
    public class InventoryHUDView : HUDElement<InventoryView>
    {
        [SerializeField] private Transform _slotsParent;

        private InventoryView _inventoryView;
        private List<InventoryHUDSlot> _slots;
        private InventoryHUDSlot _slotPrefab;

        public override void Initialize(IHUDService service)
        {
            _slotPrefab = Resources.Load<InventoryHUDSlot>(AssetPaths.HUD_INVENTORY_SLOT);

            base.Initialize(service);
        }

        public override void Assign(InventoryView input)
        {
            _inventoryView = input;

            _slots = new List<InventoryHUDSlot>();
            for (int i = 0; i < InventoryController.SLOTS_COUNT; i++)
            {
                _slots.Add(Instantiate(_slotPrefab, _slotsParent));
            }

            SubscribeToEvents();
        }

        protected override void SubscribeToEvents()
        {
            base.SubscribeToEvents();

            _inventoryView.OnViewStateChanged += OnViewStateChanged;
        }

        protected override void UnsibscribeFromEvents()
        {
            base.UnsibscribeFromEvents();

            _inventoryView.OnViewStateChanged -= OnViewStateChanged;
        }

        private void OnViewStateChanged(ItemComponent[] items, int selectedIdx)
        {
            for (int i = 0; i < items.Length; i++)
            {
                _slots[i].SetItemImage(items[i]);

                if (i == selectedIdx)
                    _slots[i].Select();
                else
                    _slots[i].Deselect();
            }
        }
    }
}