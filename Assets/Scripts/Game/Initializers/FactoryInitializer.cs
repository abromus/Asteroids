using System.Collections.Generic;
using Asteroids.Core;
using Asteroids.Core.Settings;
using Asteroids.Game.Factory;
using Asteroids.Game.Settings;

namespace Asteroids.Game.Initializers
{
    public sealed class FactoryInitializer : IFactoryInitializer
    {
        private readonly IGame _game;
        private readonly IUpdater _updater;

        public FactoryInitializer(IGame game, IUpdater updater)
        {
            _game = game;
            _updater = updater;
        }

        public void Initialize()
        {
            InitFactories();
        }

        private void InitFactories()
        {
            var uiFactories = _game.GameData.ConfigStorage.GetUiFactoryConfig().UiFactories;

            InitAsteroidFactory(uiFactories);
            InitBulletFactory(uiFactories);
            InitFlyingSaucerFactory(uiFactories);
            InitShipFactory(uiFactories);
        }

        private void InitAsteroidFactory(IReadOnlyList<IUiFactory> uiFactories)
        {
            var viewFactory = uiFactories.GetAsteroidViewFactory();
            var config = _game.GameData.ConfigStorage.GetAsteroidConfig();
            var factory = new AsteroidFactory(_updater, viewFactory, config) as IAsteroidFactory;

            _game.GameData.FactoryStorage.AddFactory(viewFactory);
            _game.GameData.FactoryStorage.AddFactory(factory);
        }

        private void InitBulletFactory(IReadOnlyList<IUiFactory> uiFactories)
        {
            var viewFactory = uiFactories.GetBulletViewFactory();
            var config = _game.GameData.ConfigStorage.GetBulletConfig();
            var factory = new BulletFactory(_updater, viewFactory, config) as IBulletFactory;

            _game.GameData.FactoryStorage.AddFactory(viewFactory);
            _game.GameData.FactoryStorage.AddFactory(factory);
        }

        private void InitFlyingSaucerFactory(IReadOnlyList<IUiFactory> uiFactories)
        {
            var viewFactory = uiFactories.GetFlyingSaucerViewFactory();
            var config = _game.GameData.ConfigStorage.GetFlyingSaucerConfig();
            var factory = new FlyingSaucerFactory(_updater, viewFactory, config) as IFlyingSaucerFactory;

            _game.GameData.FactoryStorage.AddFactory(viewFactory);
            _game.GameData.FactoryStorage.AddFactory(factory);
        }

        private void InitShipFactory(IReadOnlyList<IUiFactory> uiFactories)
        {
            var viewFactory = uiFactories.GetShipViewFactory();
            var config = _game.GameData.ConfigStorage.GetShipConfig();
            var inputSystem = _game.GameData.ServiceStorage.GetInputSystem();
            var inputConfig = _game.GameData.ConfigStorage.GetInputConfig();
            var bulletFactory = _game.GameData.FactoryStorage.GetBulletFactory();
            var factory = new ShipFactory(_updater, viewFactory, config, inputSystem, inputConfig, bulletFactory) as IShipFactory;

            _game.GameData.FactoryStorage.AddFactory(viewFactory);
            _game.GameData.FactoryStorage.AddFactory(factory);
        }
    }
}
