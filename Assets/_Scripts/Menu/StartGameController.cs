using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;

namespace ProjectKYS.Menu
{
    public class StartGameController : MonoBehaviour
    {
        [SerializeField] private GameObject _panel;
        [Space]
        [SerializeField] private GameSaveSlotVisual[] _saveSlots = new GameSaveSlotVisual[4];
        [SerializeField] private Button _closeButton;

        private string _savePath;

        public void Initialize()
        {
            if (Application.isEditor)
                _savePath = $"{Application.dataPath}/Editor/Save/";
            else
                _savePath = $"{Application.persistentDataPath}/Save/";

            for (int i = 0; i < _saveSlots.Length; i++)
            {
                if(!Directory.Exists($"{_savePath}Slot{i}/"))
                {
                    Directory.CreateDirectory($"{_savePath}Slot{i}/");
                }
                _saveSlots[i].Initialize(i);
            }

            _closeButton.onClick.AddListener(Close);
        }

        private void Close()
        {
            _panel.SetActive(false);
        }
    }
}
