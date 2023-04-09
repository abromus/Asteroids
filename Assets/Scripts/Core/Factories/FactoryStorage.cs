using System;
using System.Collections.Generic;
using Asteroids.Core.Factories;
using Asteroids.Core.Settings;

namespace Asteroids.Core.Services
{
    public sealed class FactoryStorage : IFactoryStorage
    {
        private readonly IReadOnlyList<IUiFactory> _uiFactories;
        private readonly Dictionary<Type, IFactory> _factories;

        public FactoryStorage(IConfigStorage configStorage)
        {
            _uiFactories = configStorage.GetUiFactoryConfig().UiFactories;

            var gameSceneControllerFactory = _uiFactories.GetGameSceneControllerFactory();

            _factories = new Dictionary<Type, IFactory>()
            {
                [typeof(IGameSceneControllerFactory)] = gameSceneControllerFactory,
            };
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
