using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ProjectKYS.Inventory
{
    [CreateAssetMenu(fileName = "Item", menuName = "Game/new Item")]
    public class InventoryItem : ScriptableObject
    {
        [SerializeField] private string _name;
        [SerializeField] private Sprite _icon;

        public string Name => _name;
        public Sprite Icon => _icon;
    }
}
