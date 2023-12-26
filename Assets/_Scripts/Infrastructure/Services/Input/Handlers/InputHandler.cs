namespace ProjectKYS.Infrasturcture.Services.Input
{
    public abstract class InputHandler
    {
        protected readonly InputMap _inputMap;

        public InputHandler(InputMap inputMap)
        {
            _inputMap = inputMap;
        }

        public abstract void SetActive(bool active);
        public abstract void Dispose();
    }
}
