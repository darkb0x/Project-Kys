using ProjectKYS.Infrasturcture.Services;
using ProjectKYS.Infrasturcture.Services.HUD;
using ProjectKYS.Player;

namespace ProjectKYS.Infrasturcture.Services.Factory
{
    public interface IGameFactory : IService
    {
        public PlayerController CurrentPlayer { get; set; }
        public PlayerController CreatePlayer(Input.IInputService inputService, IHUDService hudService);
        public HUDContainer CreateHUD(IHUDService service);
    }
}
