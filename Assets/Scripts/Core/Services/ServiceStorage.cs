using System;
using System.Collections.Generic;
using System.Linq;
using Asteroids.Core.Settings;

namespace Asteroids.Core.Services
{
    public sealed class ServiceStorage : IServiceStorage
    {
        private readonly IReadOnlyList<IUiService> _uiServices;
        private readonly Dictionary<Type, IService> _services;

        public ServiceStorage(ICoroutineRunner coroutineRunner, IGame game, IConfigStorage configStorage)
        {
            _uiServices = configStorage.GetConfig<IUiServiceConfig>().UiServices;

            var inputSystem = _uiServices.FirstOrDefault(service => service.UiServiceType == UiServiceType.InputSystem) as IInputSystem;
            var screenSystem = _uiServices.FirstOrDefault(service => service.UiServiceType == UiServiceType.ScreenSystem) as IScreenSystem;

            _services = new Dictionary<Type, IService>()
            {
                [typeof(IInputSystem)] = inputSystem,
                [typeof(IScreenSystem)] = screenSystem,
                [typeof(IStateMachine)] = new StateMachine(
                    game,
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
