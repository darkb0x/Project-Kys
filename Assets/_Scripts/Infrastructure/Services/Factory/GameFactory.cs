using ProjectKYS.Player;
using UnityEngine;

namespace ProjectKYS.Infrasturcture.Services.Factory
{
    public class GameFactory : IGameFactory
    {
        private PlayerController _playerPrefab;

        public GameFactory()
        {
            _playerPrefab = Resources.Load<PlayerController>(AssetPaths.PLAYER);
        }

        public PlayerController CreatePlayer()
        {
            var player = Object.Instantiate(_playerPrefab);
            player.Initialize();

            return player;
        }
    }
}
