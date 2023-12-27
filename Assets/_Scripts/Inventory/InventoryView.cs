using NaughtyAttributes;
using ProjectKYS.Infrasturcture.Services.HUD;
using ProjectKYS.Infrasturcture.Services.Input;
using ProjectKYS.Inventory.HUD;
using System;
using System.Collections;
using UnityEngine;

namespace ProjectKYS.Inventory
{
    public class InventoryView : MonoBehaviour
    {
        [SerializeField] private Transform _selectedItemViewTransform;
        [SerializeField] private Transform _selectedItemDropPosition;
        [Space]
        [SerializeField, Layer] private int _itemLayer;
        [SerializeField, Layer] private int _itemViewLayer;

        public Action<ItemComponent[], int> OnViewStateUpdated;

        private InventoryHUDView _hudView;

        public void Initialize(IHUDService hudService)
        {
            _hudView = hudService.GetHudElement<InventoryHUDView>();
            _hudView.Assign(this);
        }

        public void UpdateView(ItemComponent[] items, int activeIdx)
        {
            for (int i = 0; i < items.Length; i++)
                items[i]?.gameObject.SetActive(i == activeIdx);

            OnViewStateUpdated?.Invoke(items, activeIdx);
        }
        public void AddItem(ItemComponent item)
        {
            item.gameObject.SetActive(false);
            item.transform.SetParent(_selectedItemViewTransform);
            item.transform.localPosition = Vector3.zero;
            item.transform.localRotation = Quaternion.identity;
            ChangeLayer(item.gameObject, _itemViewLayer);
            item.gameObject.SetActive(true);
        }
        public void RemoveItem(ItemComponent item)
        {
            item.gameObject.SetActive(false);
            item.transform.SetParent(null);
            item.transform.position = _selectedItemDropPosition.position;
            ChangeLayer(item.gameObject, _itemLayer);
            item.gameObject.SetActive(true);
        }

        private void ChangeLayer(GameObject target, int layer)
        {
            target.layer = layer;

            foreach (Transform child in target.transform)
            {
                child.gameObject.layer = layer;

                Transform hasChild = child.GetComponentInChildren<Transform>();
                if (hasChild != null)
                    ChangeLayer(hasChild.gameObject, layer);
            }
        }
    }
}