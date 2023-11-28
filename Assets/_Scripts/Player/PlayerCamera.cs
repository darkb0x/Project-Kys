using System.Collections;
using UnityEngine;

namespace ProjectKYS.Player
{
    public class PlayerCamera : MonoBehaviour
    {
        [SerializeField] private Camera _camera;

        private void Awake()
        {
            _camera.backgroundColor = RenderSettings.fogColor;
        }
    }
}