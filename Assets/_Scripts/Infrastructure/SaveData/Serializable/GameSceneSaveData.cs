using ProjectKYS.Infrasturcture.SaveData.Variables;
using System;
using UnityEngine;

namespace ProjectKYS.Infrasturcture.SaveData
{
    [Serializable]
    public class GameSceneSaveData
    {
        public string SceneName;
        public GamePlayerSaveData Player;
        [SerializeReference] public GameSceneObjectStateSaveData[] SceneObjects;

        public GameSceneSaveData(string sceneName, GamePlayerSaveData player, params GameSceneObjectStateSaveData[] sceneObjects)
        {
            SceneName = sceneName;
            Player = player;
            SceneObjects = sceneObjects;
        }
    }
}
