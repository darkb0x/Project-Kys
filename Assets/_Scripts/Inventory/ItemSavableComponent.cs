using ProjectKYS.Infrasturcture.SaveData;
using ProjectKYS.Infrasturcture.SaveData.SceneObjects;
using ProjectKYS.Player;
using System.Collections;
using UnityEngine;

namespace ProjectKYS.Inventory
{
    [RequireComponent(typeof(ItemComponent))]
    public class ItemSavableComponent : SavableSceneObject
    {
        private InventoryController _inventoryController => PlayerController.Instance.InventoryController;

        public override GameSceneObjectSaveData Save(GameProgressSaveData save)
        {
            return new GameItemComponentSaveData(
                ID,
                gameObject.activeSelf,
                transform.position.ToSaveData(),
                transform.eulerAngles.ToSaveData(),
                _inventoryController.GetSlotIndexByItem(GetComponent<ItemComponent>())
                );
        }
        public override void Load(GameProgressSaveData save, GameSceneObjectSaveData objSave)
        {
            if(objSave is GameItemComponentSaveData saveData)
            {
                transform.position = saveData.Position.ToUnityVector();
                transform.eulerAngles = saveData.Rotation.ToUnityVector();
                gameObject.SetActive(saveData.Enabled);

                if(saveData.SlotIndex != -1)
                {
                    _inventoryController.SetItemToSlot(saveData.SlotIndex, GetComponent<ItemComponent>());
                }
            }
        }
    }
}