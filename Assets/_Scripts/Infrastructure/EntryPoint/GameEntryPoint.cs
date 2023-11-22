using NaughtyAttributes;
using ProjectKYS.Infrasturcture.SaveData;
using ProjectKYS.Infrasturcture.SaveData.Variables;
using ProjectKYS.Infrasturcture.Services.Factory;
using ProjectKYS.Infrasturcture.Services.Save;
using ProjectKYS.Infrasturcture.Services.Scene;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace ProjectKYS.Infrasturcture.EntryPoint
{
    public class GameEntryPoint : MonoBehaviour
    {
        public static GameEntryPoint Instance { get; private set; }

        [Header("Scenes")]
        [SerializeField, Scene] private string _initialSceneName;
        [SerializeField, Scene] private string _fisrtLocationSceneName;

        [Header("Save")]
        [SerializeField] private bool _resetAtStart = false;

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
            SceneManager.LoadScene(_initialSceneName);

            _serviceLocator = new ServiceLocator();
            RegisterServices();

            DontDestroyOnLoad(this);

            if(startScene != _initialSceneName)
            {
                SceneManager.LoadScene(startScene);
            }
        }

        private void RegisterServices()
        {
            _serviceLocator.Set<IGameFactory>(new GameFactory());
            _serviceLocator.Set<ISceneService>(new SceneService(this));
            _serviceLocator.Set<ISaveService>(new SaveService(
                new GameSceneSaveData(_fisrtLocationSceneName, new GamePlayerSaveData())
                ));
        }

        [Button]
        private void Save()
            => _serviceLocator.Get<ISaveService>().Save();

        [Button]
        private void Load()
            => _serviceLocator.Get<ISaveService>().Load();

        [Button]
        private void ResetSave()
            => _serviceLocator.Get<ISaveService>().Reset();
    }
}
