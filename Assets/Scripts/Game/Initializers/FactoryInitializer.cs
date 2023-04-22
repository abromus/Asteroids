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
            var screenSystem = _game.GameData.ServiceStorage.GetScreenSystem();
            var bounds = screenSystem.Bounds;

            InitAsteroidFactory(uiFactories, bounds);
            InitBulletFactory(uiFactories);
            InitFlyingSaucerFactory(uiFactories, bounds);
            InitMachineGunFactory(uiFactories);
            InitShipFactory(uiFactories, screenSystem);
        }

        private void InitAsteroidFactory(IReadOnlyList<IUiFactory> uiFactories, Bounds bounds)
        {
            var viewFactory = uiFactories.GetAsteroidViewFactory();
            var config = _game.GameData.ConfigStorage.GetAsteroidConfig();
            var factory = new AsteroidFactory(_updater, viewFactory, config, bounds) as IAsteroidFactory;

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

        private void InitFlyingSaucerFactory(IReadOnlyList<IUiFactory> uiFactories, Bounds bounds)
        {
            var viewFactory = uiFactories.GetFlyingSaucerViewFactory();
            var config = _game.GameData.ConfigStorage.GetFlyingSaucerConfig();
            var factory = new FlyingSaucerFactory(_updater, viewFactory, config, bounds) as IFlyingSaucerFactory;

            _game.GameData.FactoryStorage.AddFactory(viewFactory);
            _game.GameData.FactoryStorage.AddFactory(factory);
        }

        private void InitMachineGunFactory(IReadOnlyList<IUiFactory> uiFactories)
        {
            var positionCheckService = _game.GameData.ServiceStorage.GetPositionCheckService();
            var timerService = _game.GameData.ServiceStorage.GetTimerService();
            var viewFactory = uiFactories.GetMachineGunViewFactory();
            var config = _game.GameData.ConfigStorage.GetMachineGunConfig();
            var bulletFactory = _game.GameData.FactoryStorage.GetBulletFactory();
            var factory = new MachineGunFactory(_updater, timerService, positionCheckService, viewFactory, config, bulletFactory) as IMachineGunFactory;

            _game.GameData.FactoryStorage.AddFactory(viewFactory);
            _game.GameData.FactoryStorage.AddFactory(factory);
        }

        private void InitShipFactory(IReadOnlyList<IUiFactory> uiFactories, Services.IScreenSystem screenSystem)
        {
            var viewFactory = uiFactories.GetShipViewFactory();
            var config = _game.GameData.ConfigStorage.GetShipConfig();
            var inputSystem = _game.GameData.ServiceStorage.GetInputSystem();
            var inputConfig = _game.GameData.ConfigStorage.GetInputConfig();
            var machineGunFactory = _game.GameData.FactoryStorage.GetMachineGunFactory();
            var factory = new ShipFactory(_updater, viewFactory, config, inputSystem, inputConfig, screenSystem, machineGunFactory) as IShipFactory;

            _game.GameData.FactoryStorage.AddFactory(viewFactory);
            _game.GameData.FactoryStorage.AddFactory(factory);
        }
    }
}
