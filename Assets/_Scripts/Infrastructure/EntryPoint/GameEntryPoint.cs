using NaughtyAttributes;
using ProjectKYS.Infrasturcture.SaveData;
using ProjectKYS.Infrasturcture.SaveData.Variables;
using ProjectKYS.Infrasturcture.Services.Factory;
using ProjectKYS.Infrasturcture.Services.Save;
using ProjectKYS.Infrasturcture.Services.Scene;
using UnityEngine;

namespace ProjectKYS.Infrasturcture.EntryPoint
{
    public class GameEntryPoint : MonoBehaviour
    {
        public static GameEntryPoint Instance { get; private set; }

        [SerializeField, Scene] private string _initialSceneName;

        private ServiceLocator _serviceLocator;

        private void Awake()
        {
            if(Instance != null)
            {
                Destroy(gameObject);
                return;
            }

            Instance = this;

            _serviceLocator = new ServiceLocator();
            RegisterServices();

            DontDestroyOnLoad(this);
        }

        private void RegisterServices()
        {
            _serviceLocator.Set<ISceneService>(new SceneService(this));
            _serviceLocator.Set<IGameFactory>(new GameFactory());
            _serviceLocator.Set<ISaveService>(new SaveService(new GameSceneSaveData(_initialSceneName, new Vector3SaveData())));
        }
    }
}
