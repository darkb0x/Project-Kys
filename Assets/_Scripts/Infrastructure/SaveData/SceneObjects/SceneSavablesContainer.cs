using ProjectKYS.Infrasturcture.SaveData.SceneObjects;
using ProjectKYS.Infrasturcture.Services.Save;
using ProjectKYS.Infrasturcture.Services.Scene;
using ProjectKYS.Player;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace ProjectKYS.Infrasturcture.SaveData.SceneObjects
{
    public class SceneSavablesContainer : MonoBehaviour
    {
        private ISaveService _saveService;
        private PlayerController _player;
        private SaveReaderSceneObject[] _saveReader;

        public void Initialize(PlayerController player, ISaveService saveService)
        {
            _player = player;
            _saveService = saveService;
            _saveService.OnSave += Save;
            _saveService.OnLoad += Load;
        }
        private void OnDestroy()
        {
            _saveService.OnSave -= Save;
            _saveService.OnLoad -= Load;
        }

        private void Save(GameProgressSaveData save)
        {
            _saveReader = FindObjectsOfType<SaveReaderSceneObject>(true);

            List<GameSceneObjectStateSaveData> savables = new List<GameSceneObjectStateSaveData>();
            foreach (var reader in _saveReader)
            {
                if(reader is SavableSceneObject savable)
                {
                    savable.Save(save);
                    savables.Add(savable.ToObjectStateSaveData());
                }
            }
            save.ActiveSceneSaveData.SceneObjects = savables.ToArray();
        }
        private void Load(GameProgressSaveData save)
        {
            _saveReader = FindObjectsOfType<SaveReaderSceneObject>(true);

            foreach (var reader in _saveReader)
            {
                reader.Load(save);
            }
        }
    }
}