using UnityEngine;
using UnityEngine.InputSystem;

namespace ProjectKYS.Infrasturcture.Services.Input
{
    public class UIInputHandler : InputHandler
    {
        public event InputCallbackDelegate CloseEvent;
        public event InputCallbackDelegate StopItemInspectEvent;

        public UIInputHandler(InputMap inputMap) : base(inputMap)
        {
            _inputMap.UI.Close.performed += OnClose;
            _inputMap.UI.StopItemInspect.performed += OnStopItemInspect;
        }

        public override void Dispose()
        {
            _inputMap.UI.Close.performed -= OnClose;
            _inputMap.UI.StopItemInspect.performed -= OnStopItemInspect;
        }

        public override void SetActive(bool active)
        {
            if (active)
                _inputMap.UI.Enable();
            else
                _inputMap.UI.Disable();
        }

        public Vector2 GetInspectDirection()
            => _inputMap.UI.InspectItemDirection.ReadValue<Vector2>();
        private void OnClose(InputAction.CallbackContext _)
            => CloseEvent?.Invoke();
        private void OnStopItemInspect(InputAction.CallbackContext _)
            => StopItemInspectEvent?.Invoke();
    }
}
