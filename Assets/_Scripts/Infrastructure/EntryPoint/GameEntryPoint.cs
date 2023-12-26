using NaughtyAttributes;
using ProjectKYS.Infrasturcture.SaveData;
using ProjectKYS.Infrasturcture.SaveData.Variables;
using ProjectKYS.Infrasturcture.Services.Cutscene;
using ProjectKYS.Infrasturcture.Services.Factory;
using ProjectKYS.Infrasturcture.Services.Input;
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
            _serviceLocator.Set<IInputService>(new InputService());
            _serviceLocator.Set<ISceneService>(new SceneService(this));
            _serviceLocator.Set<ISaveService>(new SaveService(
                new GameSceneSaveData(_fisrtLocationSceneName)
                ));
            _serviceLocator.Set<ICutsceneService>(new CutsceneService(this));
        }

        [Button]
        private void SaveSlot1()
            => _serviceLocator.Get<ISaveService>().Save(0);
        [Button]
        private void SaveSlot2()
            => _serviceLocator.Get<ISaveService>().Save(1);
        [Button]
        private void SaveSlot3()
            => _serviceLocator.Get<ISaveService>().Save(2);
        [Button]
        private void SaveSlot4()
            => _serviceLocator.Get<ISaveService>().Save(3);
    }
}
