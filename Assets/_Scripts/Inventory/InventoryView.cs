using System.Collections;
using UnityEngine;

namespace ProjectKYS.Inventory
{
    public class InventoryView : MonoBehaviour
    {
        [SerializeField] private Transform _selectedItemViewTransform;

        public void SetItemActive(ItemComponent[] items, int activeIdx)
        {
            for (int i = 0; i < items.Length; i++)
                items[i]?.gameObject.SetActive(i == activeIdx);
        }
        public void AddItem(ItemComponent item)
        {
            item.gameObject.SetActive(false);
            item.transform.SetParent(_selectedItemViewTransform);
            item.transform.localPosition = Vector3.zero;
            item.transform.localRotation = Quaternion.identity;
            item.gameObject.SetActive(true);
        }
        public void RemoveItem(ItemComponent item)
        {
            item.gameObject.SetActive(false);
            item.transform.SetParent(null);
            item.gameObject.SetActive(true);
        }
    }
}