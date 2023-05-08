using System;
using Asteroids.Core;
using Asteroids.Game.Factory;
using Asteroids.Game.Services;
using Asteroids.Game.Settings;

namespace Asteroids.Game
{
    public sealed class AsteroidSpawner : IAsteroidSpawner<IAsteroidPresenter>
    {
        private readonly IAsteroidStorage _asteroidStorage;
        private readonly IAsteroidStorageFragment _asteroidStorageFragment;

        public Action AsteroidDestroyed { get; set; }

        public Action AsteroidFragmentDestroyed { get; set; }

        public AsteroidSpawner(
            IAsteroidSpawnerConfig config,
            IAsteroidFactory factory,
            IPositionCheckService positionCheckService,
            ITimerService timerService,
            Bounds bounds)
        {
            _asteroidStorage = new AsteroidStorage(factory, positionCheckService, timerService, bounds, config.SpawnDelay);
            _asteroidStorageFragment = new AsteroidStorageFragment(factory, positionCheckService, config.FragmentCount);

            _asteroidStorage.AsteroidDestroyed += _asteroidStorageFragment.CreateAsteroidFragment;

            for (int i = 0; i < config.MaxCount; i++)
                _asteroidStorage.SpawnAsteroid();
        }

        public void Destroy()
        {
            _asteroidStorage.Destroy();
            _asteroidStorageFragment.Destroy();
        }

        public void Tick(float deltaTime)
        {
            _asteroidStorage.Tick();
            _asteroidStorageFragment.Tick();
        }

        public IAsteroidPresenter Spawn()
        {
            return _asteroidStorage.SpawnAsteroid();
        }
    }
}
