using System.Collections;
using UnityEngine;

namespace ProjectKYS.SceneProps.Portal
{
    public class PortalsManager : MonoBehaviour
    {
        [SerializeField] private PortalsPair[] _portals;

        public void Initialize(Camera initialCamera)
        {
            foreach (var item in _portals)
            {
                item.Initialize(initialCamera);
            }
        }
        public void SetTargetCamera(Camera cam)
        {
            foreach (var item in _portals)
            {
                item.SetTargetCamera(cam);
            }
        }
    }
}