using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ProjectKYS.Infrasturcture.Services.HUD
{
    public class HUDContainer : MonoBehaviour
    {
        [SerializeField] private List<HUDElement> _hudElements = new List<HUDElement>();

        public void Initialize(IHUDService service)
        {
            _hudElements.ForEach(x => x.Initialize(service));
        }

        public IReadOnlyList<HUDElement> GetHUDElements()
            => _hudElements;
    }
}
