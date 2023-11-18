using ProjectKYS.Player.Controls;
using ProjectKYS.Infrasturcture.Services;
using System.Collections;
using UnityEngine;

namespace ProjectKYS.Player
{
    [RequireComponent(typeof(PlayerMove)),
    RequireComponent(typeof(PlayerLook)),
    RequireComponent(typeof(PlayerInteract))]
    public class PlayerController : MonoBehaviour, IService
    {
        [SerializeField] private Camera _camera;

        [Header("Components")]
        [SerializeField] private CursorLocker _cursorLocker;
        [Space]
        [SerializeField] private PlayerMove _playerMoveComponent;
        [SerializeField] private PlayerLook _playerLookComponent;
        [SerializeField] private PlayerInteract _playerInteractComponent;

        public CursorLocker CursorLocker => _cursorLocker;
        public PlayerMove PlayerMove => _playerMoveComponent;
        public PlayerLook PlayerLook => _playerLookComponent;
        public PlayerInteract PlayerInteract => _playerInteractComponent;

        public void Initialize()
        {
            _cursorLocker.Initialize();
            _playerMoveComponent.Initialize();
            _playerLookComponent.Initialize(_camera.transform);
        }

        public void SetEnableControls(bool value)
        {
            _playerMoveComponent.CanMoving = value;
            _playerLookComponent.CanLook = value;
            _playerInteractComponent.enabled = value;
        }

        public Vector3 GetRotation()
            => transform.eulerAngles;
    }
}