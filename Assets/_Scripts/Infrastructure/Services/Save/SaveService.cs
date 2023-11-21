using ProjectKYS.Infrasturcture.SaveData;
using System;
using UnityEngine.SceneManagement;

namespace ProjectKYS.Infrasturcture.Services.Save
{
    public class SaveService : ISaveService
    {
        public Action<GameProgressSaveData> OnSave { get => _onSave; set => _onSave = value; }
        public Action<GameProgressSaveData> OnLoad { get => _onLoad; set => _onLoad = value; }
        public GameProgressSaveData SaveData { get => _save; }

        private Action<GameProgressSaveData> _onSave;
        private Action<GameProgressSaveData> _onLoad;
        private GameProgressSaveData _save;

        public SaveService(GameSceneSaveData initialScene)
        {
            // deserealization
            // Load(...)
        }

        public void Save()
        {
            OnSave?.Invoke(_save);

            // serealization
        }
        public void Load(GameProgressSaveData save)
        {
            _save = save;

            LoadSaveData();
        }

        private void LoadSaveData()
        {
            SceneManager.LoadScene(_save.ActiveScene);

            OnLoad?.Invoke(_save);
        }
    }
}
