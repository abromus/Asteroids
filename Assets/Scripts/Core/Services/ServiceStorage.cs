using System;
using System.Collections.Generic;
using System.Linq;
using Asteroids.Settings;

namespace Asteroids.Core.Services
{
    public sealed class ServiceStorage : IServiceStorage
    {
        private readonly Dictionary<Type, IService> _services;

        public ServiceStorage(ICoroutineRunner coroutineRunner, IConfigStorage configStorage)
        {
            var screenSystem = configStorage.GetConfig<IUiServiceConfig>().UiServices
                .FirstOrDefault(service => service.UiServiceType == UiServiceType.ScreenSystem) as IScreenSystem;

            _services = new Dictionary<Type, IService>()
            {
                [typeof(IScreenSystem)] = screenSystem,
                [typeof(IStateMachine)] = new StateMachine(
                    screenSystem,
                    new SceneLoader(coroutineRunner),
                    configStorage.GetConfig<ICanvasConfig>()),
            };
        }

        public TService GetService<TService>() where TService : class, IService
        {
            return _services[typeof(TService)] as TService;
        }
    }
}
