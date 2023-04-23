using Asteroids.Core;
using Asteroids.Game.Services;
using Asteroids.Game.Settings;

namespace Asteroids.Game
{
    public sealed class Game : IGame
    {
        private readonly IGameData _gameData;
        private readonly IUpdater _updater;

        private IShipPresenter _shipPresenter;
        private IAsteroidSpawner<IAsteroidPresenter> _asteroidSpawner;
        private IFlyingSaucerSpawner<IFlyingSaucerPresenter> _flyingSaucerSpawner;

        public IGameData GameData => _gameData;

        public Game(IGameData gameData, IUpdater updater)
        {
            _gameData = gameData;
            _updater = updater;
        }

        public void Destroy()
        {
            _shipPresenter.Destroy();
            _asteroidSpawner.Destroy();
            _flyingSaucerSpawner.Destroy();
        }

        public void Run()
        {
            CreateShip();
            CreateEnemies();
            CreateHud();
        }

        private void CreateShip()
        {
            var factory = _gameData.FactoryStorage.GetShipFactory();

            _shipPresenter = factory.Create();
            _shipPresenter.Enable();
        }

        private void CreateEnemies()
        {
            var positionCheckService = _gameData.ServiceStorage.GetPositionCheckService();
            var timerService = _gameData.ServiceStorage.GetTimerService();
            var bounds = _gameData.ServiceStorage.GetScreenSystem().Bounds;

            CreateAsteroids(positionCheckService, timerService, bounds);

            CreateFlyingSaucers(positionCheckService, timerService, bounds);
        }

        private void CreateAsteroids(IPositionCheckService positionCheckService, ITimerService timerService, Bounds bounds)
        {
            var asteroidSpawnerConfig = _gameData.ConfigStorage.GetAsteroidSpawnerConfig();
            var asteroidFactory = _gameData.FactoryStorage.GetAsteroidFactory();

            _asteroidSpawner = new AsteroidSpawner(asteroidSpawnerConfig, asteroidFactory, positionCheckService, timerService, bounds);
            _updater.Add(_asteroidSpawner);
        }

        private void CreateFlyingSaucers(IPositionCheckService positionCheckService, ITimerService timerService, Bounds bounds)
        {
            var flyingSaucerSpawnerConfig = _gameData.ConfigStorage.GetFlyingSaucerSpawnerConfig();
            var flyingSaucerFactory = _gameData.FactoryStorage.GetFlyingSaucerFactory();

            _flyingSaucerSpawner = new FlyingSaucerSpawner(flyingSaucerSpawnerConfig, flyingSaucerFactory, positionCheckService, timerService, bounds, _shipPresenter);
            _updater.Add(_flyingSaucerSpawner);
        }

        private void CreateHud()
        {
            var screenSystem = _gameData.ServiceStorage.GetScreenSystem();
            screenSystem.ShowGame(_shipPresenter);
        }
    }
}
