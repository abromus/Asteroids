using Asteroids.Core;

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

        public Game(IGameData gameData)
        {
            _gameData = gameData;
        }

        public void Destroy()
        {
            _shipPresenter.Destroy();
            _asteroidPresenter.Destroy();
            _flyingSaucerPresenter.Destroy();
        }

        public void Run()
        {
            CreateMachineGun();
            CreateShip();
            CreateEnemies();
        }

        private void CreateMachineGun()
        {
            var factory = _gameData.FactoryStorage.GetMachineGunFactory();

            //_machineGunPresenter = factory.Create();
            //_machineGunPresenter.Enable();
        }

        private void CreateShip()
        {
            var factory = _gameData.FactoryStorage.GetShipFactory();

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
            var factory = _gameData.FactoryStorage.GetAsteroidFactory();

            _asteroidPresenter = factory.Create();
            _asteroidPresenter.Enable();
        }

        private void CreateFlyingSaucers()
        {
            var factory = _gameData.FactoryStorage.GetFlyingSaucerFactory();

            _flyingSaucerPresenter = factory.Create();
            _flyingSaucerPresenter.Enable();
        }
    }
}
