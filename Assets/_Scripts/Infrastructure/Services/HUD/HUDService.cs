using ProjectKYS.Infrasturcture.Services.Factory;

namespace ProjectKYS.Infrasturcture.Services.HUD
{
    public class HUDService : IHUDService
    {
        private HUDContainer _hudContainer;

        public void AssignHUDContainer(HUDContainer hudContainer)
        {
            _hudContainer = hudContainer;
        }

        public T GetHudElement<T>() where T : HUDElement
        {
            var elements = _hudContainer.GetHUDElements();
            foreach (var element in elements) 
            {
                if (element is T tElement)
                    return tElement;
            }
            return null;
        }
    }
}
