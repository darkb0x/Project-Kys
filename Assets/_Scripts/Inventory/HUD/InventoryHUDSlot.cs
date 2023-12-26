using System.Collections;
using UnityEngine;
using UnityEngine.UI;

namespace ProjectKYS.Inventory.HUD
{
    public class InventoryHUDSlot : MonoBehaviour
    {
        [SerializeField] private Image _itemImage;
        [SerializeField] private GameObject _highlightSelectionObj;

        public void SetItemImage(ItemComponent item)
        {
            if (item == null)
                _itemImage.color = new Color(1, 1, 1, 0);
            else
            {
                _itemImage.color = new Color(1, 1, 1, 1);
                _itemImage.sprite = item.Item.Icon;
            }
        }

        public void Select()
            => _highlightSelectionObj.SetActive(true);
        public void Deselect()
            => _highlightSelectionObj?.SetActive(false);
    }
}