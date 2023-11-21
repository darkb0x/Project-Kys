using ProjectKYS.Infrasturcture.SaveData.SceneObjects;
using ProjectKYS.Infrasturcture.Services.Save;
using ProjectKYS.Player;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace ProjectKYS.Infrasturcture.SaveData.SceneObjects
{
    public class SceneSavablesContainer : MonoBehaviour
    {
        private ISaveService _saveService;
        private SaveReaderSceneObject[] _saveReader;
        private PlayerController _player;

        private void Awake()
        {
            _saveService = ServiceLocator.Instance.Get<ISaveService>();
            _saveService.OnSave += Save;
            _saveService.OnLoad += Load;
        }
        private void Start()
        {
            _saveReader = FindObjectsOfType<SaveReaderSceneObject>(true);
            _player = FindObjectOfType<PlayerController>(true);
        }

        private void Save(GameProgressSaveData save)
        {
            if(!save.SceneSaveData.Any(x=> x.SceneName == SceneName()))
            {
                List<GameSceneObjectStateSaveData> sceneObjects = new List<GameSceneObjectStateSaveData>();
                foreach (var reader in _saveReader)
                {
                    if (reader is SavableSceneObject savable)
                    {
                        sceneObjects.Add(savable.ToObjectStateSaveData());
                    }
                }

                save.SceneSaveData.Add(new GameSceneSaveData(SceneName(), _player.transform.position.ToSaveData(), sceneObjects.ToArray()));

                return; 
            }

            foreach (var reader in _saveReader)
            {
                if(reader is SavableSceneObject savable)
                {
                    savable.Save(save);
                }
            }
        }
        private void Load(GameProgressSaveData save)
        {
            foreach (var reader in _saveReader)
            {
                reader.Load(save);
            }
        }

        private string SceneName()
            => SceneManager.GetActiveScene().name;
    }
}