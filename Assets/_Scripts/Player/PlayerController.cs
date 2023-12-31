﻿using ProjectKYS.Player.Controls;
using UnityEngine;
using ProjectKYS.Infrasturcture.SaveData;
using ProjectKYS.Infrasturcture.SaveData.SceneObjects;
using ProjectKYS.Inventory;
using ProjectKYS.Infrasturcture.Services.HUD;
using ProjectKYS.Infrasturcture.Services.Factory;

namespace ProjectKYS.Player
{
    [RequireComponent(typeof(PlayerMove)),
    RequireComponent(typeof(PlayerLook)),
    RequireComponent(typeof(PlayerInteract))]
    public class PlayerController : SavableSceneObject
    {
        public static PlayerController Instance { get; private set; }

        [SerializeField] private Camera _camera;

        [Header("Components")]
        [SerializeField] private CursorLocker _cursorLocker;
        [Space]
        [SerializeField] private PlayerMove _playerMoveComponent;
        [SerializeField] private PlayerLook _playerLookComponent;
        [SerializeField] private PlayerInteract _playerInteractComponent;
        [SerializeField] private InventoryController _inventoryController;

        public Camera Camera => _camera;
        public CursorLocker CursorLocker => _cursorLocker;
        public PlayerMove PlayerMove => _playerMoveComponent;
        public PlayerLook PlayerLook => _playerLookComponent;
        public PlayerInteract PlayerInteract => _playerInteractComponent;
        public InventoryController InventoryController => _inventoryController;


        public void Initialize(Infrasturcture.Services.Input.IInputService inputService, IHUDService hudService, IGameFactory gameFactory)
        {
            Instance = this;

            hudService.AssignHUDContainer(gameFactory.CreateHUD(hudService));

            _cursorLocker.Initialize();
            _playerMoveComponent.Initialize(inputService);
            _playerLookComponent.Initialize(_camera.transform, inputService);
            _playerInteractComponent.Initialize(_inventoryController, inputService, hudService);
            _inventoryController.Initialize(_playerInteractComponent, inputService, hudService);
        }

        public void SetEnabled(bool value)
        {
            _camera.enabled = value;
            _playerMoveComponent.CanMoving = value;
            _playerLookComponent.CanLook = value;
            _playerInteractComponent.enabled = value;
            _inventoryController.enabled = value;
        }

        public Vector3 GetRotation()
            => transform.eulerAngles;

        public override GameSceneObjectSaveData Save(GameProgressSaveData save)
        {
            save.ActiveSceneSaveData.Player = new GamePlayerSaveData(
                transform.position.ToSaveData(),
                transform.eulerAngles.ToSaveData(),
                _camera.transform.localEulerAngles.ToSaveData(),
                _inventoryController.SelectedSlot
                );

            return new GameSceneObjectSaveData(ID, gameObject.activeSelf);
        }

        public override void Load(GameProgressSaveData save)
        {
            var sceneSaveData = save.ActiveSceneSaveData;

            if (sceneSaveData.Player == null || sceneSaveData.Player.Empty)
                return;

            Vector3 playerOffset = new Vector3(0, 0.2f, 0);
            _playerMoveComponent.SetPositionAndRotation(sceneSaveData.Player.PlayerPos.ToUnityVector() + playerOffset, sceneSaveData.Player.PlayerRot.ToUnityVector());
            _camera.transform.localEulerAngles = sceneSaveData.Player.PlayerCameraRot.ToUnityVector();
            _inventoryController.SelectSlot(sceneSaveData.Player.SelectedSlot);
        }
    }
}