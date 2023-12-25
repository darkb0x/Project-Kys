﻿using ProjectKYS.Infrasturcture.Services;
using ProjectKYS.Player;

namespace ProjectKYS.Infrasturcture.Services.Factory
{
    public interface IGameFactory : IService
    {
        public PlayerController CurrentPlayer { get; set; }
        public PlayerController CreatePlayer();
    }
}
