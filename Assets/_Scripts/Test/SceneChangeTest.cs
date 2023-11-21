using NaughtyAttributes;
using ProjectKYS.Infrasturcture.Services.Scene;
using System.Collections;
using UnityEngine;

namespace ProjectKYS.Test
{
    public class SceneChangeTest : MonoBehaviour
    {
        [SerializeField] private InteractableGameObject _interactable;
        [SerializeField, Scene] private string _nextScene;

        private ISceneService _sceneService;

        private void Awake()
        {
            _sceneService = ServiceLocator.Instance.Get<ISceneService>();
        }
        private void Start()
        {        
            _sceneService.LoadAndActivateAfterAction(_interactable, _nextScene, () => Debug.Log("loaded"));
        }
    }
}