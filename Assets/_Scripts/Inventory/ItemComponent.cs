using System.Collections;
using UnityEngine;

namespace ProjectKYS.Inventory
{
    public class ItemComponent : Interactable
    {
        [SerializeField] private InventoryItem _item;
        [SerializeField] private Rigidbody _rigidbody;

        public InventoryItem Item => _item;
        public Rigidbody Rigidbody => _rigidbody;
        public override string InteractableName => _item.Name;

        public override void Interact()
        {
            base.Interact();
        }
    }
}