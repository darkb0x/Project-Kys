using ProjectKYS.Infrasturcture.SaveData.Variables;
using System;
using UnityEngine;

namespace ProjectKYS.Infrasturcture.SaveData
{
    [Serializable]
    public class GameSceneSaveData
    {
        public string SceneName;
        public Vector3SaveData PlayerPos;
        [SerializeReference] public GameSceneObjectStateSaveData[] SceneObjects;

        public GameSceneSaveData(string sceneName, Vector3SaveData playerPos, params GameSceneObjectStateSaveData[] sceneObjects)
        {
            SceneName = sceneName;
            PlayerPos = playerPos;
            SceneObjects = sceneObjects;
        }
    }
}
