using UnityEngine;

namespace ProjectKYS.SceneProps.Portal
{
    public class Portal : MonoBehaviour
    {
        [SerializeField] private Camera _portalView;

        private Portal _other;
        private Camera _currentCamera;

        public void Initialize(Portal otherPortal, Camera targetCam)
        {
            SetTargetCamera(targetCam);
            _other = otherPortal;
            _other._portalView.targetTexture = new RenderTexture(Screen.width, Screen.height, 24);
            GetComponentInChildren<MeshRenderer>().sharedMaterial.mainTexture = _other._portalView.targetTexture;
            _portalView.backgroundColor = RenderSettings.fogColor;
        }

        private void Update()
        {
            // Position
            Vector3 lookerPosition = _other.transform.worldToLocalMatrix.MultiplyPoint3x4(_currentCamera.transform.position);
            lookerPosition = new Vector3(-lookerPosition.x, lookerPosition.y, -lookerPosition.z);
            _portalView.transform.localPosition = lookerPosition;

            // Rotation
            Quaternion difference = transform.rotation * Quaternion.Inverse(_other.transform.rotation * Quaternion.Euler(0, 180, 0));
            _portalView.transform.rotation = difference * _currentCamera.transform.rotation;

            // Clipping
            _portalView.nearClipPlane = lookerPosition.magnitude;
        }

        public void SetTargetCamera(Camera cam)
        {
            _currentCamera = cam;
        }
    }
}
