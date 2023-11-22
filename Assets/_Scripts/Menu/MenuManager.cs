using ProjectKYS.Infrasturcture.Services.Save;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace ProjectKYS.Menu
{
    public class MenuManager : MonoBehaviour
    {
        [SerializeField] private Button _startButton;
        [SerializeField] private Button _settingsButton;
        [SerializeField] private Button _exitButton;

        [Header("StartGame")]
        [SerializeField] private StartGameController _startGameController;
        [SerializeField] private GameObject _startGamePanel;

        private void Awake()
        {
            InitializeButtons();

            _startGameController.Initialize();
        }

        private void InitializeButtons()
        {
            _startButton.onClick.AddListener(BtnStart);
            _settingsButton.onClick.AddListener(BtnSettings);
            _exitButton.onClick.AddListener(BtnExit);
        }

        private void BtnStart()
        {
            _startGamePanel.SetActive(true);
        }
        private void BtnSettings()
        {
            // soon
            return;
        }
        private void BtnExit()
        {
            Application.Quit();
        }
    }
}
