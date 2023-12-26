using ProjectKYS.Infrasturcture.Services.HUD;
using ProjectKYS.Infrasturcture.Services.Input;
using ProjectKYS.Player;
using UnityEngine;

namespace ProjectKYS.Infrasturcture.Services.Factory
{
    public class GameFactory : IGameFactory
    {
        private readonly PlayerController _playerPrefab;
        private readonly HUDContainer _hudPrefab;

        public PlayerController CurrentPlayer 
        { 
            get => _currentPlayer; 
            set => _currentPlayer = value;
        }

        private PlayerController _currentPlayer;

        public GameFactory()
        {
            _playerPrefab = Resources.Load<PlayerController>(AssetPaths.PLAYER);
            _hudPrefab = Resources.Load<HUDContainer>(AssetPaths.HUD);
        }

        public PlayerController CreatePlayer(IInputService inputService, IHUDService hudService)
        {
            var player = Object.Instantiate(_playerPrefab);
            player.Initialize(inputService, hudService, this);

            CurrentPlayer = player;
            return player;
        }
        public HUDContainer CreateHUD(IHUDService service)
        {
            var hud = Object.Instantiate(_hudPrefab);
            hud.Initialize(service);

            return hud;
        }
    }
}
