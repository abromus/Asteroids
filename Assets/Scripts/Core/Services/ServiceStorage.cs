using System;
using System.Collections.Generic;
using Asteroids.Core.Settings;

namespace Asteroids.Core.Services
{
    public sealed class ServiceStorage : IServiceStorage
    {
        private readonly IReadOnlyList<IUiService> _uiServices;
        private readonly Dictionary<Type, IService> _services;

        public ServiceStorage(ICoroutineRunner coroutineRunner, IGameData gameData, IConfigStorage configStorage)
        {
            _uiServices = configStorage.GetUiServiceConfig().UiServices;

            var inputSystem = _uiServices.GetInputSystem();
            var stateMachine = InitStateMachine(coroutineRunner, gameData);

            _services = new Dictionary<Type, IService>()
            {
                [typeof(IInputSystem)] = inputSystem,
                [typeof(IStateMachine)] = stateMachine,
            };
        }

        public void AddService<TService>(TService service) where TService : class, IService
        {
            var type = typeof(TService);

            if (_services.ContainsKey(type))
                _services[type] = service;
            else
                _services.Add(type, service);
        }

        public TService GetService<TService>() where TService : class, IService
        {
            return _services[typeof(TService)] as TService;
        }

        private StateMachine InitStateMachine(ICoroutineRunner coroutineRunner, IGameData gameData)
        {
            var stateMachine = new StateMachine();

            stateMachine.Add(new BootstrapState(stateMachine));
            stateMachine.Add(new GameState(stateMachine));
            stateMachine.Add(new SceneLoaderState(new SceneLoader(coroutineRunner)));
            stateMachine.Add(new GameLoopState(gameData));

            return stateMachine;
        }
    }
}
