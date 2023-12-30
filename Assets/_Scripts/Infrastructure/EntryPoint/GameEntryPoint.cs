using NaughtyAttributes;
using ProjectKYS.Infrasturcture.SaveData;
using ProjectKYS.Infrasturcture.SaveData.Variables;
using ProjectKYS.Infrasturcture.Services.Cutscene;
using ProjectKYS.Infrasturcture.Services.Factory;
using ProjectKYS.Infrasturcture.Services.HUD;
using ProjectKYS.Infrasturcture.Services.Input;
using ProjectKYS.Infrasturcture.Services.Save;
using ProjectKYS.Infrasturcture.Services.Scene;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections.Generic;
using ProjectKYS.Configs;

namespace ProjectKYS.Infrasturcture.EntryPoint
{
    public class GameEntryPoint : MonoBehaviour
    {
        public static GameEntryPoint Instance { get; private set; }

        [Header("Scenes")]
        [SerializeField] private SceneConfigSO _sceneConfig;

        [Header("Save")]
        [SerializeField] private bool DebugLoadSlot1;

        private ServiceLocator _serviceLocator;

        private void Awake()
        {
            if(Instance != null)
            {
                Destroy(gameObject);
                return;
            }

            string startScene = SceneManager.GetActiveScene().name;

            Instance = this;
            SceneManager.LoadScene(_sceneConfig.InitialSceneName);

            _serviceLocator = new ServiceLocator();
            RegisterServices();

            DontDestroyOnLoad(this);

            if(startScene != _sceneConfig.InitialSceneName)
            {
                SceneManager.LoadScene(startScene);
            }

            if (DebugLoadSlot1)
                LoadSlot1();
        }

        private void RegisterServices()
        {
            _serviceLocator.Set<IGameFactory>(new GameFactory());
            _serviceLocator.Set<IInputService>(new InputService());
            _serviceLocator.Set<ISceneService>(new SceneService(this));
            _serviceLocator.Set<ISaveService>(new SaveService(
                new GameSceneSaveData(_sceneConfig.FirstLocationSceneName, new List<GameSceneObjectSaveData>())
                ));
            _serviceLocator.Set<ICutsceneService>(new CutsceneService(this));
            _serviceLocator.Set<IHUDService>(new HUDService());
        }

        [Button]
        private void SaveSlot1()
            => _serviceLocator.Get<ISaveService>().Save(0);
        [Button]
        private void LoadSlot1()
            => _serviceLocator.Get<ISaveService>().Load(0);
    }
}
