using System;
using System.Collections.Generic;
using Asteroids.Core;
using Asteroids.Game.Factory;
using Asteroids.Game.Services;

namespace Asteroids.Game
{
    public sealed class AsteroidStorage : IAsteroidStorage
    {
        private readonly IAsteroidFactory _factory;
        private readonly IPositionCheckService _positionCheckService;
        private readonly ITimerService _timerService;
        private readonly float _spawnDelay;

        private readonly IList<IAsteroidPresenter> _asteroids;
        private readonly IList<ITimer> _timers;
        private readonly ISpawnerHelper _spawnerHelper;

        public Action<Float3> AsteroidDestroyed { get; set; }

        public AsteroidStorage(IAsteroidFactory factory, IPositionCheckService positionCheckService, ITimerService timerService, Bounds bounds, float spawnDelay)
        {
            _factory = factory;
            _positionCheckService = positionCheckService;
            _timerService = timerService;
            _spawnDelay = spawnDelay;

            _asteroids = new List<IAsteroidPresenter>();
            _timers = new List<ITimer>();
            _spawnerHelper = new SpawnerHelper(bounds);
        }

        public void Destroy()
        {
            DestroyTimers();

            DestroyAsteroids();
        }

        public void Tick()
        {
            for (int i = _asteroids.Count - 1; i >= 0; i--)
            {
                var asteroidPresenter = _asteroids[i];

                if (!asteroidPresenter.IsDestroyed)
                    continue;

                DestroyAsteroid(asteroidPresenter);

                CreateTimer();
            }
        }

        public IAsteroidPresenter SpawnAsteroid()
        {
            var asteroidPresenter = CreateAsteroid();
            _asteroids.Add(asteroidPresenter);

            return asteroidPresenter;
        }

        private IAsteroidPresenter CreateAsteroid()
        {
            var rotation = GetRotation();
            var position = _spawnerHelper.CalculatePosition(rotation);

            var asteroidPresenter = _factory.Create();
            asteroidPresenter.Init(position);
            asteroidPresenter.Enable();
            asteroidPresenter.Destroyed += OnAsteroidDestroyed;

            _positionCheckService.AddDamagable(asteroidPresenter);

            return asteroidPresenter;
        }

        private void DestroyAsteroid(IAsteroidPresenter asteroidPresenter)
        {
            asteroidPresenter.Disable();

            _asteroids.Remove(asteroidPresenter);
            _positionCheckService.RemoveDamagable(asteroidPresenter);
            _factory.Release(asteroidPresenter);
        }

        private void DestroyAsteroids()
        {
            for (int i = _asteroids.Count - 1; i >= 0; i--)
                DestroyAsteroid(_asteroids[i]);

            _asteroids.Clear();

            AsteroidDestroyed = null;
        }

        private Float3 GetRotation()
        {
            var angle = MathUtils.Value * MathUtils.FullAngle;
            var rotation = MathUtils.CalculateRotation(angle, Float3.Zero);

            return rotation;
        }

        private void CreateTimer()
        {
            var timer = _timerService.CreateTimer(_spawnDelay);
            timer.Elapsed += OnElapsed;
            _timers.Add(timer);
        }

        private void DestroyTimers()
        {
            for (int i = _timers.Count - 1; i >= 0; i--)
            {
                var timer = _timers[i];

                _timers.Remove(timer);
                _timerService.RemoveTimer(timer);

                timer.Destroy();
            }
        }

        private void OnAsteroidDestroyed(IAsteroidPresenter asteroidPresenter)
        {
            asteroidPresenter.Destroyed -= OnAsteroidDestroyed;

            AsteroidDestroyed.SafeInvoke(asteroidPresenter.Position);
        }

        private void OnElapsed(ITimer timer)
        {
            timer.Elapsed -= OnElapsed;

            _timers.Remove(timer);
            _timerService.RemoveTimer(timer);

            SpawnAsteroid();
        }
    }
}
