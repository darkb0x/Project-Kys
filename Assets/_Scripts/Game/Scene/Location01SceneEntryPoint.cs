using ProjectKYS.SceneProps;
using ProjectKYS.SceneProps.Portal;
using UnityEngine;

namespace ProjectKYS.Scene
{
    public class Location01SceneEntryPoint : SceneEntryPoint
    {
        [SerializeField] private StalkingBloodSpot _bloodSpot;
        [SerializeField] private PortalsManager _portalsManager;

        protected override void OnStart()
        {
            base.OnStart();

            _bloodSpot.Initialize(_player);

            Camera portalsCam = _playCutsceneOnStart ? _cutsceneController.CutsceneCamera : _player.Camera;
            _portalsManager.Initialize(portalsCam);
        }
    }
}
