using Asteroids.Core;

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

        public Game(IGameData gameData)
        {
            _gameData = gameData;
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
            var asteroidFactory = _gameData.FactoryStorage.GetAsteroidFactory();
            _asteroidSpawner = new AsteroidSpawner(asteroidFactory);

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
