using System;
using UnityEngine;
using UnityEngine.InputSystem;

namespace ProjectKYS.Infrasturcture.Services.Input
{
    public class PlayerInputHandler : InputHandler
    {
        public event InputCallbackDelegate InteractEvent;
        public event InputCallbackDelegate<int> SelectItemEvent;
        public event InputCallbackDelegate DropItemEvent;

        public PlayerInputHandler(InputMap inputMap) : base(inputMap)
        {
            _inputMap.Player.Interact.performed += OnInteract;
            _inputMap.Player.SelectItem.performed += OnSelectItem;
            _inputMap.Player.DropItem.performed += OnDropItem;
        }

        public override void Dispose()
        {
            _inputMap.Player.Interact.performed -= OnInteract;
            _inputMap.Player.SelectItem.performed -= OnSelectItem;
            _inputMap.Player.DropItem.performed -= OnDropItem;
        }

        public override void SetActive(bool active)
        {
            if (active)
                _inputMap.Player.Enable();
            else
                _inputMap.Player.Disable();
        }

        public Vector2 GetMovement()
            => _inputMap.Player.Movement.ReadValue<Vector2>();
        public Vector2 GetMouseDelta()
            => _inputMap.Player.MouseDelta.ReadValue<Vector2>();
        private void OnInteract(InputAction.CallbackContext _) 
            => InteractEvent?.Invoke();
        private void OnSelectItem(InputAction.CallbackContext ctx)
            => SelectItemEvent?.Invoke((int)ctx.ReadValue<float>());
        private void OnDropItem(InputAction.CallbackContext _)
            => DropItemEvent?.Invoke();
    }
}
