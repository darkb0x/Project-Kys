using ProjectKYS.Infrasturcture.Factory;
using ProjectKYS.Infrasturcture.Services;
using ProjectKYS.Player;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ProjectKYS.Infrasturcture.EntryPoint
{
    public class GameEntryPoint : MonoBehaviour
    {
        public static GameEntryPoint Instance { get; private set; }

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
            _serviceLocator.Set<IGameFactory>(new GameFactory());
            _serviceLocator.Set<PlayerController>(_serviceLocator.Get<IGameFactory>().CreatePlayer());
        }
    }
}
