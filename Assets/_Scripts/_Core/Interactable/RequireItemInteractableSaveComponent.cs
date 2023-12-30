using ProjectKYS.Infrasturcture.SaveData;
using ProjectKYS.Infrasturcture.SaveData.SceneObjects;
using System.Collections;
using UnityEngine;

namespace ProjectKYS
{
    [RequireComponent(typeof(RequireItemInteractable))]
    public class RequireItemInteractableSaveComponent : SavableSceneObject
    {
        [SerializeField] private RequireItemInteractable _requireItemInteractable;

        public override GameSceneObjectSaveData Save(GameProgressSaveData save)
        {
            var data = _requireItemInteractable.Save(save);
            data.ID = ID;
            data.Enabled = gameObject.activeSelf;

            return data;
        }

        public override void Load(GameProgressSaveData save, GameSceneObjectSaveData objSave)
        {
            _requireItemInteractable.Load(save, objSave as GameDynamicalSaveData);
        }
    }
}