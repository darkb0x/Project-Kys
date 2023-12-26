using ProjectKYS.Infrasturcture.Services.Input;
using ProjectKYS.Player;
using UnityEngine;

namespace ProjectKYS.Infrasturcture.Services.Factory
{
    public class GameFactory : IGameFactory
    {
        public PlayerController CurrentPlayer 
        { 
            get => _currentPlayer; 
            set => _currentPlayer = value;
        }

        private PlayerController _currentPlayer;
        private PlayerController _playerPrefab;

        public GameFactory()
        {
            _playerPrefab = Resources.Load<PlayerController>(AssetPaths.PLAYER);
        }

        public PlayerController CreatePlayer(IInputService inputService)
        {
            var player = Object.Instantiate(_playerPrefab);
            player.Initialize(inputService);

            CurrentPlayer = player;
            return player;
        }
    }
}
