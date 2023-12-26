namespace ProjectKYS.Infrasturcture.Services.Input
{
    public class UIInputHandler : InputHandler
    {
        public UIInputHandler(InputMap inputMap) : base(inputMap)
        {
        }

        public override void Dispose()
        {

        }

        public override void SetActive(bool active)
        {
            if (active)
                _inputMap.UI.Enable();
            else
                _inputMap.UI.Disable();
        }
    }
}
