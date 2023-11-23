using ProjectKYS.Infrasturcture.SaveData;
using System;

namespace ProjectKYS.Infrasturcture.Services.Save
{
    public interface ISaveService : IService
    {
        public Action<GameProgressSaveData> OnSave { get; set; }
        public Action<GameProgressSaveData> OnLoad { get; set; }
        public GameProgressSaveData SaveData { get; }

        public void Save(int slotIdx);
        public bool Load(int slotIdx);
        public void Reset(int slotIdx, bool load = true);
    }
}