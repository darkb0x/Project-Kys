using ProjectKYS.Infrasturcture.SaveData;
using ProjectKYS.Inventory;
using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Events;

namespace ProjectKYS
{
    public class RequireItemInteractable : Interactable
    {
        protected const string USED_SAVEDATA_KEY = "Used";

        public enum ItemUseType { Take, Use }

        [SerializeField] private string _interactableName;
        [Space]
        [SerializeField] private InventoryItem _requiredItem;
        [SerializeField] private ItemUseType _useType = ItemUseType.Take;
        [SerializeField] private bool _deactivateAfterUsage = true;
        [Space]
        [SerializeField] private UnityEvent _onActivated;

        public override string InteractableName => GetShowedText();
        public bool Used => _used;

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

        public void SetUsedState(bool value)
        {
            _used = value;
            if (_used)
                Interact();
        }

        public virtual GameSceneObjectSaveData Save(GameProgressSaveData save)
        {
            return new GameDynamicalSaveData(
                new GameDynamicalSaveData.DataBool(USED_SAVEDATA_KEY, _used)
                );
        }
        public virtual void Load(GameProgressSaveData save, GameDynamicalSaveData objDynamicSave)
        {
            if(objDynamicSave.GetData(USED_SAVEDATA_KEY, out GameDynamicalSaveData.DataBool data))
            {
                SetUsedState(data.Value);
            }
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