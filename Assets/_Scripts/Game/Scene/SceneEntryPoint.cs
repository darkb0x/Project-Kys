using NaughtyAttributes;
using ProjectKYS.Cutscene;
using ProjectKYS.Infrasturcture.SaveData.SceneObjects;
using ProjectKYS.Infrasturcture.Services.Cutscene;
using ProjectKYS.Infrasturcture.Services.HUD;
using ProjectKYS.Infrasturcture.Services.Input;
using ProjectKYS.Infrasturcture.Services.Save;
using ProjectKYS.Player;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ProjectKYS
{
    public class SceneEntryPoint : MonoBehaviour
    {
        [SerializeField] protected PlayerSpawnPoint _playerSpawnPoint;
        [SerializeField] protected CutsceneController _cutsceneController;
        [SerializeField] protected SceneSavablesContainer _sceneSavablesContainer;

        [Header("Scene")]
        [SerializeField] protected bool _playCutsceneOnStart;
        [SerializeField, ShowIf("_playCutsceneOnStart")] protected string _startCutsceneName;

        protected PlayerController _player;

        private void Awake()
        {
            OnAwake();
        }
        private void Start()
        {
            OnStart();
        }

        protected virtual void OnAwake()
        {
            _player = _playerSpawnPoint.SpawnPlayer(ServiceLocator.Instance.Get<IInputService>(), ServiceLocator.Instance.Get<IHUDService>()); ;
            _sceneSavablesContainer.Initialize(ServiceLocator.Instance.Get<ISaveService>());
            _cutsceneController.Initialize(_player, ServiceLocator.Instance.Get<ICutsceneService>());
        }
        protected virtual void OnStart()
        {
            if (_playCutsceneOnStart)
                ServiceLocator.Instance.Get<ICutsceneService>().PlayCutscene(_startCutsceneName);
        }
    }
}
