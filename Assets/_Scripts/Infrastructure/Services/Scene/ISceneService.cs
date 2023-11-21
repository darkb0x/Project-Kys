using System;

namespace ProjectKYS.Infrasturcture.Services.Scene
{
    public interface ISceneService : IService
    {
        public void Load(string sceneName, Action onLoad = null);
        public void LoadAndActivateAfterAction(ISceneLoadActivator activator, string sceneName, Action onLoad = null);
        public void Unload(string sceneName);
    }
}
