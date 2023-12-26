using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ProjectKYS.Infrasturcture.Services.Input
{
    public interface IInputService : IService
    {
        PlayerInputHandler GetPlayerInputHandler();
        UIInputHandler GetUIInputHandler();

        void SetDefaultInputMap();
        void SetInputMap(InputMapType actionMap);
    }
}
