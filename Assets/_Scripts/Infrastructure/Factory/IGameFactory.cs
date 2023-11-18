using ProjectKYS.Infrasturcture.Services;
using ProjectKYS.Player;

namespace ProjectKYS.Infrasturcture.Factory
{
    public interface IGameFactory : IService
    {
        public PlayerController CreatePlayer();
    }
}
