using ProjectKYS.Infrasturcture.SaveData;
using ProjectKYS.Infrasturcture.Services.Scene;
using ProjectKYS.Utilities;
using System;
using System.IO;
using UnityEngine;

namespace ProjectKYS.Infrasturcture.Services.Save
{
    public class SaveService : ISaveService
    {
        private const string SAVE_FILE_NAME = "Save";

        private readonly GameSceneSaveData _initialScene;
        private readonly string _path;

        public Action<GameProgressSaveData> OnSave { get => _onSave; set => _onSave = value; }
        public Action<GameProgressSaveData> OnLoad { get => _onLoad; set => _onLoad = value; }
        public GameProgressSaveData SaveData { get => _save; }

        private Action<GameProgressSaveData> _onSave;
        private Action<GameProgressSaveData> _onLoad;
        private GameProgressSaveData _save;

        public SaveService(GameSceneSaveData initialScene)
        {
            _initialScene = initialScene;

            if (Application.isEditor)
                _path = $"{Application.dataPath}/Editor/Save/";
            else
                _path = $"{Application.persistentDataPath}/Save/";

            if (!Directory.Exists(_path))
                Directory.CreateDirectory(_path);
        }

        public void Save(int slotIdx)
        {
            if (_save == null)
                Reset(slotIdx, false);

            OnSave?.Invoke(_save);

            _save.ActiveSceneSaveData.SceneName = SceneService.GetActiveSceneName();

            SaveUtility.SaveDataToJson($"{_path}Slot{slotIdx}/", SAVE_FILE_NAME, _save);
        }
        public bool Load(int slotIdx)
        {
            _save = SaveUtility.LoadDataFromJson<GameProgressSaveData>($"{_path}Slot{slotIdx}/", SAVE_FILE_NAME);

            if (_save != null)
            {
                LoadSaveData();
                return true;
            }
            else
            {
                Reset(slotIdx);
                return false;
            }          
        }

        public void Reset(int slotIdx, bool load = true)
        {
            _save = new GameProgressSaveData(_initialScene);
            SaveUtility.SaveDataToJson($"{_path}Slot{slotIdx}/", SAVE_FILE_NAME, _save);

            if(load)
                LoadSaveData();
        }

        private void LoadSaveData()
        {
            ServiceLocator.Instance.Get<ISceneService>().Load(_save.ActiveSceneSaveData.SceneName, () => OnLoad?.Invoke(_save));
        }
    }
}
