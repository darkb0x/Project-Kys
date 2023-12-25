using ProjectKYS.Player.Controls;
using UnityEngine;
using ProjectKYS.Infrasturcture.SaveData;
using ProjectKYS.Infrasturcture.SaveData.SceneObjects;

namespace ProjectKYS.Player
{
    [RequireComponent(typeof(PlayerMove)),
    RequireComponent(typeof(PlayerLook)),
    RequireComponent(typeof(PlayerInteract))]
    public class PlayerController : SavableSceneObject
    {
        [SerializeField] private Camera _camera;

        [Header("Components")]
        [SerializeField] private CursorLocker _cursorLocker;
        [Space]
        [SerializeField] private PlayerMove _playerMoveComponent;
        [SerializeField] private PlayerLook _playerLookComponent;
        [SerializeField] private PlayerInteract _playerInteractComponent;

        public Camera Camera => _camera;
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

        public void SetEnabled(bool value)
        {
            _camera.enabled = value;
            _playerMoveComponent.CanMoving = value;
            _playerLookComponent.CanLook = value;
            _playerInteractComponent.enabled = value;
        }

        public Vector3 GetRotation()
            => transform.eulerAngles;

        public override void Save(GameProgressSaveData save)
        {
            save.ActiveSceneSaveData.Player = new GamePlayerOrientationSaveData(
                transform.position.ToSaveData(),
                transform.eulerAngles.ToSaveData(),
                _camera.transform.localEulerAngles.ToSaveData()
                );
        }

        public override void Load(GameProgressSaveData save)
        {
            var sceneSaveData = save.ActiveSceneSaveData;

            if (sceneSaveData.Player == null || sceneSaveData.Player.Empty)
                return;

            Vector3 playerOffset = new Vector3(0, 0.2f, 0);
            _playerMoveComponent.SetPositionAndRotation(sceneSaveData.Player.PlayerPos.ToUnityVector() + playerOffset, sceneSaveData.Player.PlayerRot.ToUnityVector());
            _camera.transform.localEulerAngles = sceneSaveData.Player.PlayerCameraRot.ToUnityVector();
        }
    }
}