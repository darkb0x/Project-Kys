using ProjectKYS.SceneProps;
using UnityEngine;

namespace ProjectKYS.Scene
{
    public class Location01SceneEntryPoint : SceneEntryPoint
    {
        [SerializeField] private StalkingBloodSpot _bloodSpot;

        protected override void OnStart()
        {
            base.OnStart();

            _bloodSpot.Initialize(_player);
        }
    }
}
