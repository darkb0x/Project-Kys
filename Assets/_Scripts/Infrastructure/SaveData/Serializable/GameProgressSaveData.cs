using System;
using System.Collections.Generic;
using System.Linq;

namespace ProjectKYS.Infrasturcture.SaveData
{
    [Serializable]
    public class GameProgressSaveData
    {
        public int SaveIndex;
        public GameSceneSaveData ActiveSceneSaveData;

        public GameProgressSaveData(GameSceneSaveData initialSceneSaveData)
        {
            ActiveSceneSaveData = initialSceneSaveData;
        }
    }
}
