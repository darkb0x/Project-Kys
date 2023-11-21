using System;

namespace ProjectKYS
{
    public interface ISceneLoadActivator
    {
        public Action OnActivateScene { get; set; }
    }
}
