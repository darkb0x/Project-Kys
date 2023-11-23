using ProjectKYS.Infrasturcture.Services.Save;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

namespace ProjectKYS.Menu
{
    public class GameSaveSlotVisual : MonoBehaviour
    {
        [SerializeField] private Button _startButton;
        [SerializeField] private Button _clearButton;

        private ISaveService _saveService;
        private int _slotIndex;

        public void Initialize(int slotIndex)
        {
            _saveService = ServiceLocator.Instance.Get<ISaveService>();
            _slotIndex = slotIndex;

            _startButton.onClick.AddListener(BtnStart);
            _clearButton.onClick.AddListener(BtnClear);
        }

        private void BtnStart()
        {
            _saveService.Load(_slotIndex);
            Debug.Log($"Start game with save slot: {_slotIndex}");
        }
        private void BtnClear()
        {
            _saveService.Reset(_slotIndex, false);
            Debug.Log($"Cleared slot save: {_slotIndex}");
        }
    }
}