using System.Collections.Generic;
using Asteroids.Core;
using Asteroids.Core.Services;
using Asteroids.Core.Settings;
using Asteroids.Game.Factory;
using Asteroids.Game.Settings;

namespace Asteroids.Game.Initializers
{
    public sealed class FactoryInitializer : IFactoryInitializer
    {
        private readonly IGame _game;

        public FactoryInitializer(IGame game)
        {
            _game = game;
        }

        public void Initialize()
        {
            InitFactories();
        }

        private void InitFactories()
        {
            var uiFactories = _game.GameData.ConfigStorage.GetUiFactoryConfig().UiFactories;
            var screenSystem = _game.GameData.ServiceStorage.GetScreenSystem();
            var updater = _game.GameData.ServiceStorage.GetUpdater();
            var bounds = screenSystem.Bounds;

            InitAsteroidFactory(uiFactories, updater, bounds);
            InitBulletFactory(uiFactories, updater);
            InitFlyingSaucerFactory(uiFactories, updater, bounds);
            InitLaserFactory(uiFactories, updater);
            InitLaserGunFactory(uiFactories, updater);
            InitMachineGunFactory(uiFactories, updater);
            InitShipFactory(uiFactories, updater, bounds);
        }

        private void InitAsteroidFactory(IReadOnlyList<IUiFactory> uiFactories, IUpdater updater, Bounds bounds)
        {
            var viewFactory = uiFactories.GetAsteroidViewFactory();
            var config = _game.GameData.ConfigStorage.GetAsteroidConfig();
            var factory = new AsteroidFactory(updater, viewFactory, config, bounds) as IAsteroidFactory;

            _game.GameData.FactoryStorage.AddFactory(viewFactory);
            _game.GameData.FactoryStorage.AddFactory(factory);
        }

        private void InitBulletFactory(IReadOnlyList<IUiFactory> uiFactories, IUpdater updater)
        {
            var viewFactory = uiFactories.GetBulletViewFactory();
            var config = _game.GameData.ConfigStorage.GetBulletConfig();
            var factory = new BulletFactory(updater, viewFactory, config) as IBulletFactory;

            _game.GameData.FactoryStorage.AddFactory(viewFactory);
            _game.GameData.FactoryStorage.AddFactory(factory);
        }

        private void InitFlyingSaucerFactory(IReadOnlyList<IUiFactory> uiFactories, IUpdater updater, Bounds bounds)
        {
            var viewFactory = uiFactories.GetFlyingSaucerViewFactory();
            var config = _game.GameData.ConfigStorage.GetFlyingSaucerConfig();
            var factory = new FlyingSaucerFactory(updater, viewFactory, config, bounds) as IFlyingSaucerFactory;

            _game.GameData.FactoryStorage.AddFactory(viewFactory);
            _game.GameData.FactoryStorage.AddFactory(factory);
        }

        private void InitLaserFactory(IReadOnlyList<IUiFactory> uiFactories, IUpdater updater)
        {
            var viewFactory = uiFactories.GetLaserViewFactory();
            var config = _game.GameData.ConfigStorage.GetLaserConfig();
            var factory = new LaserFactory(updater, viewFactory, config) as ILaserFactory;

            _game.GameData.FactoryStorage.AddFactory(viewFactory);
            _game.GameData.FactoryStorage.AddFactory(factory);
        }

        private void InitLaserGunFactory(IReadOnlyList<IUiFactory> uiFactories, IUpdater updater)
        {
            var positionCheckService = _game.GameData.ServiceStorage.GetPositionCheckService();
            var timerService = _game.GameData.ServiceStorage.GetTimerService();
            var viewFactory = uiFactories.GetLaserGunViewFactory();
            var config = _game.GameData.ConfigStorage.GetLaserGunConfig();
            var laserFactory = _game.GameData.FactoryStorage.GetLaserFactory();
            var factory = new LaserGunFactory(
                updater,
                timerService,
                positionCheckService,
                viewFactory,
                config,
                laserFactory) as ILaserGunFactory;

            _game.GameData.FactoryStorage.AddFactory(viewFactory);
            _game.GameData.FactoryStorage.AddFactory(factory);
        }

        private void InitMachineGunFactory(IReadOnlyList<IUiFactory> uiFactories, IUpdater updater)
        {
            var positionCheckService = _game.GameData.ServiceStorage.GetPositionCheckService();
            var timerService = _game.GameData.ServiceStorage.GetTimerService();
            var viewFactory = uiFactories.GetMachineGunViewFactory();
            var config = _game.GameData.ConfigStorage.GetMachineGunConfig();
            var bulletFactory = _game.GameData.FactoryStorage.GetBulletFactory();
            var factory = new MachineGunFactory(
                updater,
                timerService,
                positionCheckService,
                viewFactory,
                config,
                bulletFactory) as IMachineGunFactory;

            _game.GameData.FactoryStorage.AddFactory(viewFactory);
            _game.GameData.FactoryStorage.AddFactory(factory);
        }

        private void InitShipFactory(IReadOnlyList<IUiFactory> uiFactories, IUpdater updater, Bounds bounds)
        {
            var viewFactory = uiFactories.GetShipViewFactory();
            var config = _game.GameData.ConfigStorage.GetShipConfig();
            var inputSystem = _game.GameData.ServiceStorage.GetInputSystem();
            var inputConfig = _game.GameData.ConfigStorage.GetInputConfig();
            var laserGunFactory = _game.GameData.FactoryStorage.GetLaserGunFactory();
            var machineGunFactory = _game.GameData.FactoryStorage.GetMachineGunFactory();
            var factory = new ShipFactory(
                updater,
                viewFactory,
                config,
                inputSystem,
                inputConfig,
                bounds,
                laserGunFactory,
                machineGunFactory) as IShipFactory;

            _game.GameData.FactoryStorage.AddFactory(viewFactory);
            _game.GameData.FactoryStorage.AddFactory(factory);
        }
    }
}
