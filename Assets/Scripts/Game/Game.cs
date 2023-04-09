using Asteroids.Core;
using Asteroids.Game.Factory;
using Asteroids.Game.Settings;

namespace Asteroids.Game
{
    public sealed class Game : IGame
    {
        private readonly IGameData _gameData;
        private readonly IUpdater _updater;

        private IShipPresenter _shipPresenter;
        private IAsteroidPresenter _asteroidPresenter;
        private IFlyingSaucerPresenter _flyingSaucerPresenter;

        public IGameData GameData => _gameData;

        public Game(IGameData gameData, IUpdater updater)
        {
            _gameData = gameData;
            _updater = updater;
        }

        public void Destroy()
        {
            _shipPresenter.Destroy();
            _asteroidPresenter.Destroy();
            _flyingSaucerPresenter.Destroy();
        }

        public void Run()
        {
            CreateShip();
            CreateEnemies();
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
