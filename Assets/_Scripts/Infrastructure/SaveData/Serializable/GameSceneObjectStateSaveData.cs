using System;

namespace ProjectKYS.Infrasturcture.SaveData
{
    [Serializable]
    public class GameSceneObjectStateSaveData
    {
        public int ID;
        public bool Enabled;

        public GameSceneObjectStateSaveData(int id, bool enabled)
        {
            ID = id;
            Enabled = enabled;
        }
    }
}
