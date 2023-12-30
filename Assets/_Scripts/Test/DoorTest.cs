using ProjectKYS.Infrasturcture.SaveData;
using System.Collections;
using UnityEngine;

namespace ProjectKYS.Test
{
    public class DoorTest : RequireItemInteractable
    {
        private const string DOOR_OPENED_SAVEDATA_KEY = "IsOpened";

        [SerializeField] private GameObject _doorObj;
 
        public override void Interact()
        {
            _doorObj.SetActive(!_doorObj.activeSelf);
            base.Interact();
        }

        public override GameSceneObjectSaveData Save(GameProgressSaveData save)
        {
            return new GameDynamicalSaveData(
                new GameDynamicalSaveData.DataBool(USED_SAVEDATA_KEY, Used),
                new GameDynamicalSaveData.DataBool(DOOR_OPENED_SAVEDATA_KEY, _doorObj.activeSelf)
                );
        }
        public override void Load(GameProgressSaveData save, GameDynamicalSaveData objDynamicSave)
        {
            base.Load(save, objDynamicSave);
            if(objDynamicSave.GetData(DOOR_OPENED_SAVEDATA_KEY, out GameDynamicalSaveData.DataBool data))
            {
                _doorObj.SetActive(data.Value);
            }
        }
    }
}