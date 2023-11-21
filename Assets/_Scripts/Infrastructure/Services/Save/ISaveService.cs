using ProjectKYS.Infrasturcture.SaveData;
using System;

namespace ProjectKYS.Infrasturcture.Services.Save
{
    public interface ISaveService : IService
    {
        public Action<GameProgressSaveData> OnSave { get; set; }
        public Action<GameProgressSaveData> OnLoad { get; set; }
        public GameProgressSaveData SaveData { get; }
    }
}