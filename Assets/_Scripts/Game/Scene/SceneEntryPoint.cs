using NaughtyAttributes;
using ProjectKYS.Cutscene;
using ProjectKYS.Infrasturcture.SaveData.SceneObjects;
using ProjectKYS.Infrasturcture.Services.Cutscene;
using ProjectKYS.Infrasturcture.Services.Save;
using ProjectKYS.Player;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ProjectKYS
{
    public class SceneEntryPoint : MonoBehaviour
    {
        [SerializeField] private PlayerSpawnPoint _playerSpawnPoint;
        [SerializeField] private CutsceneController _cutsceneController;
        [SerializeField] private SceneSavablesContainer _sceneSavablesContainer;

        [Header("Scene")]
        [SerializeField] private bool _playCutsceneOnStart;
        [SerializeField, ShowIf("_playCutsceneOnStart")] private string _startCutsceneName;

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
            _player = _playerSpawnPoint.SpawnPlayer();
            _sceneSavablesContainer.Initialize(_player, ServiceLocator.Instance.Get<ISaveService>());
            _cutsceneController.Initialize(_player, ServiceLocator.Instance.Get<ICutsceneService>());
        }
        protected virtual void OnStart()
        {
            if (_playCutsceneOnStart)
                ServiceLocator.Instance.Get<ICutsceneService>().PlayCutscene(_startCutsceneName);
        }
    }
}
