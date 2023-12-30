using NaughtyAttributes;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ProjectKYS.Configs
{
    [CreateAssetMenu(fileName = "SceneConfig", menuName = "Game/Configs/new Scene config")]
    public class SceneConfigSO : ScriptableObject
    {
        [SerializeField, Scene] private string _initialSceneName;
        [SerializeField, Scene] private string _firstLocationSceneName;

        public string InitialSceneName => _initialSceneName;
        public string FirstLocationSceneName => _firstLocationSceneName;
    }
}
