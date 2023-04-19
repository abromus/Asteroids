using Asteroids.Core;
using Asteroids.Game.Settings;

namespace Asteroids.Game
{
    public sealed class Game : IGame
    {
        private readonly IGameData _gameData;
        private readonly IUpdater _updater;

        private IShipPresenter _shipPresenter;
        private IFlyingSaucerPresenter _flyingSaucerPresenter;
        private IAsteroidSpawner<IAsteroidPresenter> _asteroidSpawner;

        public IGameData GameData => _gameData;

        public Game(IGameData gameData, IUpdater updater)
        {
            _gameData = gameData;
            _updater = updater;
        }

        public void Destroy()
        {
            _shipPresenter.Destroy();
            _flyingSaucerPresenter.Destroy();
        }

        public void Run()
        {
            CreateShip();
            CreateEnemies();
        }

        private void CreateShip()
        {
            var factory = _gameData.FactoryStorage.GetShipFactory();

            _shipPresenter = factory.Create();
            _shipPresenter.Enable();
        }

        private void CreateEnemies()
        {
            var asteroidSpawnerConfig = _gameData.ConfigStorage.GetAsteroidSpawnerConfig();
            var asteroidFactory = _gameData.FactoryStorage.GetAsteroidFactory();
            var positionCheckService = _gameData.ServiceStorage.GetPositionCheckService();
            var timerService = _gameData.ServiceStorage.GetTimerService();
            var bounds = _gameData.ServiceStorage.GetScreenSystem().Bounds;

            _asteroidSpawner = new AsteroidSpawner(asteroidSpawnerConfig, asteroidFactory, positionCheckService, timerService, bounds);
            _updater.Add(_asteroidSpawner);

            CreateFlyingSaucers();
        }

        private void CreateFlyingSaucers()
        {
            var factory = _gameData.FactoryStorage.GetFlyingSaucerFactory();

            _flyingSaucerPresenter = factory.Create();
            _flyingSaucerPresenter.Enable();
        }
    }
}
