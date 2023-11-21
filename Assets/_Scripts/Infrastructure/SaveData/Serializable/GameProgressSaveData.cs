using System;
using System.Collections.Generic;

namespace ProjectKYS.Infrasturcture.SaveData
{
    [Serializable]
    public class GameProgressSaveData
    {
        public string ActiveScene; 
        public List<GameSceneSaveData> SceneSaveData;

        public GameProgressSaveData(GameSceneSaveData initialSceneSaveData)
        {
            ActiveScene = initialSceneSaveData.SceneName;
            SceneSaveData = new List<GameSceneSaveData>() { initialSceneSaveData };
        }
    }
}
