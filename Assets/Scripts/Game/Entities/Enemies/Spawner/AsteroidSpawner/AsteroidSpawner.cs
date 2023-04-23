﻿using System.Collections.Generic;
using Asteroids.Core;
using Asteroids.Game.Factory;
using Asteroids.Game.Services;
using Asteroids.Game.Settings;

namespace Asteroids.Game
{
    public sealed class AsteroidSpawner : IAsteroidSpawner<IAsteroidPresenter>
    {
        private readonly IAsteroidSpawnerConfig _config;
        private readonly IAsteroidFactory _factory;
        private readonly IPositionCheckService _positionCheckService;
        private readonly ITimerService _timerService;
        private readonly Bounds _bounds;

        private readonly IList<IAsteroidPresenter> _asteroids;
        private readonly IList<IAsteroidFragmentPresenter> _asteroidFragments;
        private readonly ISpawnerHelper _spawnerHelper;
        private readonly IList<ITimer> _timers;

        public AsteroidSpawner(IAsteroidSpawnerConfig config, IAsteroidFactory factory, IPositionCheckService positionCheckService, ITimerService timerService, Bounds bounds)
        {
            _config = config;
            _factory = factory;
            _positionCheckService = positionCheckService;
            _timerService = timerService;
            _bounds = bounds;

            _asteroids = new List<IAsteroidPresenter>();
            _asteroidFragments = new List<IAsteroidFragmentPresenter>();
            _spawnerHelper = new SpawnerHelper(_bounds);
            _timers = new List<ITimer>();

            for (int i = 0; i < _config.MaxCount; i++)
                Spawn();
        }

        public IAsteroidPresenter Spawn()
        {
            var asteroidPresenter = CreateAsteroid();
            _asteroids.Add(asteroidPresenter);

            return asteroidPresenter;
        }

        public void Destroy()
        {
            DestroyTimers();

            DestroyAsteroids();
        }

        public void Tick(float deltaTime)
        {
            for (int i = 0; i < _asteroids.Count; i++)
            {
                var asteroidPresenter = _asteroids[i];

                if (!asteroidPresenter.IsDestroyed)
                    continue;

                DestroyAsteroid(asteroidPresenter);

                var timer = _timerService.CreateTimer(_config.SpawnDelay);
                timer.Elapsed += OnElapsed;
                _timers.Add(timer);

                i--;
            }

            for (int i = 0; i < _asteroidFragments.Count; i++)
            {
                var asteroidFragmentPresenter = _asteroidFragments[i];

                if (!asteroidFragmentPresenter.IsDestroyed)
                    continue;

                DestroyAsteroidFragment(asteroidFragmentPresenter);

                i--;
            }
        }

        private IAsteroidPresenter CreateAsteroid()
        {
            var asteroidPresenter = _factory.Create();

            var rotation = GetRotation();
            var position = _spawnerHelper.CalculatePosition(rotation);

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

        private void OnElapsed(ITimer timer)
        {
            timer.Elapsed -= OnElapsed;
            _timers.Remove(timer);
            _timerService.RemoveTimer(timer);

            Spawn();
        }

        private Float3 GetRotation()
        {
            var angle = MathUtils.Value * MathUtils.FullAngle;

            var rotation = MathUtils.CalculateRotation(angle, Float3.Zero);

            return rotation;
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

        private void DestroyAsteroids()
        {
            for (int i = _asteroids.Count - 1; i >= 0; i--)
            {
                var asteroid = _asteroids[i];
                DestroyAsteroid(asteroid);
            }

            _asteroids.Clear();
        }

        private void CreateAsteroidFragments(Float3 position)
        {
            for (int i = 0; i < _config.FragmentCount; i++)
            {
                var asteroidFragmentPresenter = _factory.CreateFragment();
                asteroidFragmentPresenter.Init(position);
                asteroidFragmentPresenter.Enable();

                _positionCheckService.AddDamagable(asteroidFragmentPresenter);
                _asteroidFragments.Add(asteroidFragmentPresenter);
            }
        }

        private void DestroyAsteroidFragment(IAsteroidFragmentPresenter asteroidFragmentPresenter)
        {
            asteroidFragmentPresenter.Disable();

            _asteroidFragments.Remove(asteroidFragmentPresenter);
            _positionCheckService.RemoveDamagable(asteroidFragmentPresenter);
            _factory.ReleaseFragment(asteroidFragmentPresenter);
        }

        private void OnAsteroidDestroyed(IAsteroidPresenter asteroidPresenter)
        {
            asteroidPresenter.Destroyed -= OnAsteroidDestroyed;

            CreateAsteroidFragments(asteroidPresenter.Position);
        }
    }
}
