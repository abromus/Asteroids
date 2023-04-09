using System.Linq;
using Asteroids.Core;
using Asteroids.Core.Services;
using Asteroids.Core.Settings;
using Asteroids.Game.Factory;

namespace Asteroids.Game
{
    public sealed class Game : IGame
    {
        private readonly IGameData _gameData;
        private readonly IUpdater _updater;

        private ShipPresenter _shipPresenter;

        private AsteroidPresenter _asteroidPresenter;
        private FlyingSaucerPresenter _flyingSaucerPresenter;

        public IGameData GameData => _gameData;

        public Game(IGameData gameData, IUpdater updater)
        {
            _gameData = gameData;
            _updater = updater;
        }

        public void Destroy()
        {
            _shipPresenter.Destroy();
        }

        public void Run()
        {
            /*_stateMachine = new StateMachine();
            _stateMachine.Add(new ShipState());
            _stateMachine.Add(new EnemiesState());
            _stateMachine.Add(new UiState());
            _stateMachine.Add(new NewGameState());*/

            var uiFactories = _gameData.ConfigStorage.GetUiFactoryConfig().UiFactories;
            var shipViewFactory = uiFactories.FirstOrDefault(factory => factory.UiFactoryType == UiFactoryType.ShipViewFactory) as IShipViewFactory;
            _gameData.FactoryStorage.AddFactory(shipViewFactory);

            var asteroidViewFactory = uiFactories.FirstOrDefault(factory => factory.UiFactoryType == UiFactoryType.AsteroidViewFactory) as IAsteroidViewFactory;
            _gameData.FactoryStorage.AddFactory(asteroidViewFactory);

            var flyingSaucerViewFactory = uiFactories.FirstOrDefault(factory => factory.UiFactoryType == UiFactoryType.FlyingSaucerViewFactory) as IFlyingSaucerViewFactory;
            _gameData.FactoryStorage.AddFactory(flyingSaucerViewFactory);

            CreateShip();
            CreateEnemies();
            //ShowUi();
        }

        private void CreateShip()
        {
            var viewFactory = _gameData.FactoryStorage.GetShipViewFactory();
            var inputSystem = _gameData.ServiceStorage.GetInputSystem();
            var inputConfig = _gameData.ConfigStorage.GetInputConfig();
            var config = _gameData.ConfigStorage.GetShipConfig();

            var factory = new ShipFactory(_updater, viewFactory, config, inputSystem, inputConfig);
            
            _shipPresenter = factory.Create();
            _shipPresenter.Enable();
        }

        private void CreateEnemies()
        {
            CreateAsteroids();
            CreateFlyingSaucers();
        }

        private void CreateAsteroids()
        {
            var viewFactory = _gameData.FactoryStorage.GetAsteroidViewFactory();
            var config = _gameData.ConfigStorage.GetAsteroidConfig();

            var factory = new AsteroidFactory(_updater, viewFactory, config);

            _asteroidPresenter = factory.Create();
            _asteroidPresenter.Enable();
        }

        private void CreateFlyingSaucers()
        {
            var viewFactory = _gameData.FactoryStorage.GetFlyingSaucerViewFactory();
            var config = _gameData.ConfigStorage.GetFlyingSaucerConfig();

            var factory = new FlyingSaucerFactory(_updater, viewFactory, config);

            _flyingSaucerPresenter = factory.Create();
            _flyingSaucerPresenter.Enable();
        }
    }
}
