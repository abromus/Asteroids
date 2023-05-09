using System;
using System.Collections.Generic;
using Asteroids.Core.Factories;
using Asteroids.Core.Settings;

namespace Asteroids.Core.Services
{
    public sealed class FactoryStorage : IFactoryStorage
    {
        private Dictionary<Type, IFactory> _factories;

        private readonly IUiFactoryConfig _uiFactoryConfig;

        public FactoryStorage(IConfigStorage configStorage)
        {
            _uiFactoryConfig = configStorage.GetUiFactoryConfig();

            var gameSceneControllerFactory = _uiFactoryConfig.UiFactories.GetGameSceneControllerFactory();

            _factories = new Dictionary<Type, IFactory>()
            {
                [typeof(IGameSceneControllerFactory)] = gameSceneControllerFactory,
            };
        }

        public void Destroy()
        {
            _uiFactoryConfig.Destroy();

            foreach (var factory in _factories.Values)
                factory.Destroy();

            _factories.Clear();
            _factories = null;
        }

        public void AddFactory<TFactory>(TFactory factory) where TFactory : class, IFactory
        {
            var type = typeof(TFactory);

            if (_factories.ContainsKey(type))
                _factories[type] = factory;
            else
                _factories.Add(type, factory);
        }

        public TFactory GetFactory<TFactory>() where TFactory : class, IFactory
        {
            return _factories[typeof(TFactory)] as TFactory;
        }
    }
}
