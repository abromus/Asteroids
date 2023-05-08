using Asteroids.Core;
using Asteroids.Core.Services;
using Asteroids.Game.Services;
using Asteroids.Game.Settings;

namespace Asteroids.Game
{
    public sealed class Game : IGame
    {
        private IShipPresenter _shipPresenter;
        private IAsteroidSpawner<IAsteroidPresenter> _asteroidSpawner;
        private IFlyingSaucerSpawner<IFlyingSaucerPresenter> _flyingSaucerSpawner;
        private IScoreboard _scoreboard;

        private readonly IGameData _gameData;

        public IGameData GameData => _gameData;

        public Game(IGameData gameData)
        {
            _gameData = gameData;
        }

        public void Destroy()
        {
            var inputSystem = _gameData.ServiceStorage.GetInputSystem();
            inputSystem.Hide();

            var positionCheckService = _gameData.ServiceStorage.GetPositionCheckService();
            positionCheckService.RemoveDamaging(_shipPresenter);

            var screenSystem = _gameData.ServiceStorage.GetScreenSystem();
            screenSystem.CloseAllScreens();

            (_shipPresenter as IPresenter).Destroy();
            _shipPresenter = null;

            _asteroidSpawner.Destroy();
            _asteroidSpawner = null;

            _flyingSaucerSpawner.Destroy();
            _flyingSaucerSpawner = null;

            _scoreboard.Destroy();
            _scoreboard = null;
        }

        public void Run()
        {
            var positionCheckService = _gameData.ServiceStorage.GetPositionCheckService();
            var inputSystem = _gameData.ServiceStorage.GetInputSystem();
            var screenSystem = _gameData.ServiceStorage.GetScreenSystem();

            CreateShip(positionCheckService);
            CreateEnemies(positionCheckService);
            CreateScoreboard(screenSystem);
            CreateHud(inputSystem, screenSystem);
        }

        private void CreateShip(IPositionCheckService positionCheckService)
        {
            var factory = _gameData.FactoryStorage.GetShipFactory();

            _shipPresenter = factory.Create();
            _shipPresenter.Enable();

            positionCheckService.AddDamaging(_shipPresenter);
        }

        private void CreateEnemies(IPositionCheckService positionCheckService)
        {
            var timerService = _gameData.ServiceStorage.GetTimerService();
            var updater = _gameData.ServiceStorage.GetUpdater();
            var bounds = _gameData.ServiceStorage.GetScreenSystem().Bounds;

            CreateAsteroids(positionCheckService, updater, timerService, bounds);

            CreateFlyingSaucers(positionCheckService, updater, timerService, bounds);
        }

        private void CreateAsteroids(IPositionCheckService positionCheckService, IUpdater updater, ITimerService timerService, Bounds bounds)
        {
            var asteroidSpawnerConfig = _gameData.ConfigStorage.GetAsteroidSpawnerConfig();
            var asteroidFactory = _gameData.FactoryStorage.GetAsteroidFactory();

            _asteroidSpawner = new AsteroidSpawner(
                asteroidSpawnerConfig,
                asteroidFactory,
                positionCheckService,
                timerService,
                bounds);

            updater.Add(_asteroidSpawner);
        }

        private void CreateFlyingSaucers(IPositionCheckService positionCheckService, IUpdater updater, ITimerService timerService, Bounds bounds)
        {
            var flyingSaucerSpawnerConfig = _gameData.ConfigStorage.GetFlyingSaucerSpawnerConfig();
            var flyingSaucerFactory = _gameData.FactoryStorage.GetFlyingSaucerFactory();

            _flyingSaucerSpawner = new FlyingSaucerSpawner(
                flyingSaucerSpawnerConfig,
                flyingSaucerFactory,
                positionCheckService,
                timerService,
                bounds,
                _shipPresenter);

            updater.Add(_flyingSaucerSpawner);
        }

        private void CreateScoreboard(IScreenSystem screenSystem)
        {
            _scoreboard = new Scoreboard(
                screenSystem,
                _shipPresenter,
                _asteroidSpawner,
                _flyingSaucerSpawner);

            _scoreboard.Restarted += OnRestarted;
        }

        private void CreateHud(IInputSystem inputSystem, IScreenSystem screenSystem)
        {
            inputSystem.Show();

            screenSystem.ShowGame(_shipPresenter);
        }

        private void OnRestarted()
        {
            Destroy();

            Run();
        }
    }
}
