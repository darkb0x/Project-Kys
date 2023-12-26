using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ProjectKYS.Infrasturcture.Services.Input
{
    public class InputService : IInputService
    {
        public const InputMapType DEFAUIL_INPUT_MAP = InputMapType.Player;

        private readonly InputMap _inputMap;

        public InputMapType CurrentInputMapType { get; private set; }
        public InputHandler CurrentInputHandler { get; private set; }

        private PlayerInputHandler _playerInputHandler;
        private UIInputHandler _uiInputHandler;

        public InputService()
        {
            _inputMap = new InputMap();

            _playerInputHandler = new PlayerInputHandler(_inputMap);
            _uiInputHandler = new UIInputHandler(_inputMap);

            SetDefaultInputMap();
        }

        public PlayerInputHandler GetPlayerInputHandler()
            => _playerInputHandler;

        public UIInputHandler GetUIInputHandler()
            => _uiInputHandler;

        public void SetDefaultInputMap()
        {
            SetInputMap(InputMapType.Player);
        }
        public void SetInputMap(InputMapType actionMap)
        {
            switch (actionMap)
            {
                case InputMapType.Player:
                    Enable(_playerInputHandler);
                    break;
                case InputMapType.UI:
                    Enable(_uiInputHandler);
                    break;
                default:
                    goto case InputMapType.Player;
            }

            CurrentInputMapType = actionMap;

            void Enable(InputHandler inputHandler)
            {
                _playerInputHandler.SetActive(false);
                _uiInputHandler.SetActive(false);

                inputHandler.SetActive(true);
                CurrentInputHandler = inputHandler;
            }
        }
    }
}
