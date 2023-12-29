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
        private SaveReaderSceneObject[] _saveReader;       

        public void Initialize(ISaveService saveService)
        {
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

            save.ActiveSceneSaveData.SceneObjects.Clear();
            foreach (var reader in _saveReader)
            {
                if(reader is SavableSceneObject savable)
                {
                    save.ActiveSceneSaveData.SceneObjects.Add(savable.Save(save));
                }
            }
        }
        private void Load(GameProgressSaveData save)
        {
            _saveReader = FindObjectsOfType<SaveReaderSceneObject>(true);

            foreach (var reader in _saveReader)
            {
                reader.Load(save);

                if (reader is SavableSceneObject savable)
                {
                    var objSave = save.ActiveSceneSaveData.SceneObjects.Find(x => x.ID == savable.ID);

                    if(objSave != null)
                        savable.Load(save, objSave);
                }
            }
        }
    }
}