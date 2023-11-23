using ProjectKYS.Infrasturcture.SaveData.Variables;
using System;
using UnityEngine;

namespace ProjectKYS.Infrasturcture.SaveData
{
    [Serializable]
    public class GameSceneSaveData
    {
        public string SceneName;
        public GamePlayerOrientationSaveData Player;
        [SerializeReference] public GameSceneObjectStateSaveData[] SceneObjects;

        public GameSceneSaveData(string sceneName, params GameSceneObjectStateSaveData[] sceneObjects)
        {
            SceneName = sceneName;
            Player = null;
            SceneObjects = sceneObjects;
        }
    }
}
