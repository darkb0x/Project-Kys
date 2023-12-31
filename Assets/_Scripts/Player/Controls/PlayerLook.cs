using ProjectKYS.Infrasturcture.Services.Input;
using System;
using UnityEngine;

namespace ProjectKYS.Player.Controls
{
    public class PlayerLook : MonoBehaviour
    {
        [SerializeField] private CursorLocker _locker;
        [SerializeField] private float _minX = -360;
        [SerializeField] private float _maxX = 360;
        [SerializeField] private float _minY = -90;
        [SerializeField] private float _maxY = 90;

        public float Sensitive = 1.5f;
        public bool CanLook = true;

        private IInputService _inputService;
        private Transform _camera;
        private bool _cursorLocked;
        private float _mouseX;
        private float _mouseY;
        private Quaternion _bodyOriginalRot = Quaternion.identity;
        private Quaternion _cameraOriginalRot = Quaternion.identity;

        public void Initialize(Transform cameraTransform, IInputService inputService)
        {
            _inputService = inputService;
            _camera = cameraTransform;
            ResetOrigin();

            _locker.CursorStateChanged += OnCursorStateChanched;
        }

        public void ResetOrigin()
        {
            _cameraOriginalRot = _camera.localRotation;
            _bodyOriginalRot = transform.localRotation;

            _mouseX = 0;
            _mouseY = 0;
        }

        private void Update()
        {
            if(_cursorLocked && CanLook)
                Look();
        }

        private void OnCursorStateChanched(bool value) => 
            _cursorLocked = value;

        private void Look()
        {
            Vector2 mouseDelta = _inputService.GetPlayerInputHandler().GetMouseDelta();
            _mouseX += mouseDelta.x * Sensitive;
            _mouseY += mouseDelta.y * Sensitive;

            _mouseX = _mouseX % 360;
            _mouseY = _mouseY % 360;

            _mouseX = Mathf.Clamp(_mouseX, _minX, _maxX);
            _mouseY = Mathf.Clamp(_mouseY, _minY, _maxY);

            Quaternion xQuaternion = Quaternion.AngleAxis(_mouseX, Vector3.up);
            Quaternion yQuaternion = Quaternion.AngleAxis(_mouseY, Vector3.left);

            transform.localRotation = _bodyOriginalRot * xQuaternion;
            _camera.transform.localRotation = _cameraOriginalRot * yQuaternion;
        }
    }
}
