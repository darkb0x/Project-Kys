using System;
using System.Collections.Generic;

namespace ProjectKYS.Infrasturcture.Services
{
    public class ServiceLocator
    {
        public static ServiceLocator Instance { get; private set; }

        private Dictionary<Type, IService> _services;

        public ServiceLocator()
        {
            _services = new Dictionary<Type, IService>();

            Instance = this;
        }

        public TService Set<TService>(IService service) where TService : class, IService
        {
            Type type = typeof(TService);

            if (_services.ContainsKey(type))
            {
                if (_services[type] == null)
                    _services[type] = service;
            }
            else
            {
                _services.Add(type, service);
            }

            return _services[type] as TService;
        }

        public TService Get<TService>() where TService : class, IService
        {
            if(_services.TryGetValue(typeof(TService), out IService result))
            {
                return result as TService;
            }

            return null;
        }
    }
}