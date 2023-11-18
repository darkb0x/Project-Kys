using Game.Player.Controls;
using ProjectKYS.Infrasturcture.Services;
using System.Collections;
using UnityEngine;

namespace ProjectKYS.Player
{
    [RequireComponent(typeof(PlayerMove)),
    RequireComponent(typeof(PlayerLook)),
    RequireComponent(typeof(CharacterController))]
    public class PlayerController : MonoBehaviour, IService
    {
        [SerializeField] private Camera _camera;

        [Header("Components")]
        [SerializeField] private CharacterController _characterController;
        [Space]
        [SerializeField] private CursorLocker _cursorLocker;
        [Space]
        [SerializeField] private PlayerMove _playerMoveComponent;
        [SerializeField] private PlayerLook _playerLookComponent;

        public CursorLocker CursorLocker => _cursorLocker;
        public PlayerMove PlayerMove => _playerMoveComponent;
        public PlayerLook PlayerLook => _playerLookComponent;

        public void Initialize()
        {
            _cursorLocker.Initialize();
            _playerMoveComponent.Initialize(_characterController);
            _playerLookComponent.Initialize(_camera.transform);
        }

        public void SetEnableControls(bool value)
        {
            _playerMoveComponent.CanMoving = value;
            _playerLookComponent.CanLook = value;
        }

        public Vector3 GetRotation()
            => transform.eulerAngles;
    }
}