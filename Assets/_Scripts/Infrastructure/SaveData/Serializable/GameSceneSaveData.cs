using ProjectKYS.Infrasturcture.SaveData.Variables;
using System;
using UnityEngine;
using AYellowpaper.SerializedCollections;
using System.Collections.Generic;

namespace ProjectKYS.Infrasturcture.SaveData
{
    [Serializable]
    public class GameSceneSaveData
    {
        public string SceneName;
        public GamePlayerSaveData Player;
        [SerializeReference] public List<GameSceneObjectSaveData> SceneObjects;

        public GameSceneSaveData(string sceneName, List<GameSceneObjectSaveData> sceneObjects)
        {
            SceneName = sceneName;
            Player = null;
            SceneObjects = sceneObjects;
        }
    }
}
