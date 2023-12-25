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

        public PlayerController CreatePlayer()
        {
            var player = Object.Instantiate(_playerPrefab);
            player.Initialize();

            CurrentPlayer = player;
            return player;
        }
    }
}
