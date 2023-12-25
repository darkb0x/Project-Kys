using ProjectKYS.Infrasturcture.Services.Factory;
using System.Collections;
using UnityEngine;

namespace ProjectKYS.SceneProps.Portal
{
    public class PortalsPair : MonoBehaviour
    {
        [SerializeField] private Portal _redPortal;
        [SerializeField] private Portal _bluePortal;

        public void Initialize(Camera initCam)
        {
            _redPortal.Initialize(_bluePortal, initCam);
            _bluePortal.Initialize(_redPortal, initCam);
        }
        public void SetTargetCamera(Camera cam)
        {
            _redPortal.SetTargetCamera(cam);
            _bluePortal.SetTargetCamera(cam);
        }
    }
}