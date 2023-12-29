using System;

namespace ProjectKYS.Infrasturcture.SaveData
{
    [Serializable]
    public class GameSceneObjectSaveData
    {
        public int ID;
        public bool Enabled;

        public GameSceneObjectSaveData(int id, bool enabled)
        {
            ID = id;
            Enabled = enabled;
        }
    }
}
