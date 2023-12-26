using UnityEngine;
using UnityEngine.InputSystem;

namespace ProjectKYS.Infrasturcture.Services.Input
{
    public class PlayerInputHandler : InputHandler
    {
        public event InputCallbackDelegate InteractEvent;

        public PlayerInputHandler(InputMap inputMap) : base(inputMap)
        {
            _inputMap.Player.Interact.performed += OnInteract;
        }

        public override void Dispose()
        {
            _inputMap.Player.Interact.performed -= OnInteract;
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
    }
}
