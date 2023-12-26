using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ProjectKYS.Infrasturcture.Services.HUD
{
    public interface IHUDService : IService
    {
        void AssignHUDContainer(HUDContainer container);
        T GetHudElement<T>() where T : HUDElement;
    }
}
