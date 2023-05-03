using System;
using System.Collections.Generic;
using Asteroids.Core;
using Asteroids.Game.Factory;
using Asteroids.Game.Services;
using Asteroids.Game.Settings;

namespace Asteroids.Game
{
    public sealed class FlyingSaucerSpawner : IFlyingSaucerSpawner<IFlyingSaucerPresenter>
    {
        private readonly IFlyingSaucerSpawnerConfig _config;
        private readonly IFlyingSaucerFactory _factory;
        private readonly IPositionCheckService _positionCheckService;
        private readonly ITimerService _timerService;
        private readonly Bounds _bounds;
        private readonly IShipPresenter _shipPresenter;

        private readonly IList<IFlyingSaucerPresenter> _flyingSaucers;
        private readonly ISpawnerHelper _spawnerHelper;
        private readonly IList<ITimer> _timers;

        public Action FlyingSaucerDestroyed { get; set; }

        public FlyingSaucerSpawner(
            IFlyingSaucerSpawnerConfig config,
            IFlyingSaucerFactory factory,
            IPositionCheckService positionCheckService,
            ITimerService timerService,
            Bounds bounds,
            IShipPresenter shipPresenter)
        {
            _config = config;
            _factory = factory;
            _positionCheckService = positionCheckService;
            _timerService = timerService;
            _bounds = bounds;
            _shipPresenter = shipPresenter;

            _flyingSaucers = new List<IFlyingSaucerPresenter>();
            _spawnerHelper = new SpawnerHelper(_bounds);
            _timers = new List<ITimer>();

            for (int i = 0; i < _config.MaxCount; i++)
                Spawn();
        }

        public IFlyingSaucerPresenter Spawn()
        {
            var flyingSaucerPresenter = CreateFlyingSaucer();
            _flyingSaucers.Add(flyingSaucerPresenter);

            return flyingSaucerPresenter;
        }

        public void Destroy()
        {
            FlyingSaucerDestroyed = null;

            DestroyTimers();

            DestroyFlyingSaucers();
        }

        public void Tick(float deltaTime)
        {
            for (int i = _flyingSaucers.Count - 1; i >= 0; i--)
            {
                var flyingSaucerPresenter = _flyingSaucers[i];

                if (!flyingSaucerPresenter.IsDestroyed)
                    continue;

                DestroyFlyingSaucer(flyingSaucerPresenter);

                var timer = _timerService.CreateTimer(_config.SpawnDelay);
                timer.Elapsed += OnElapsed;
                _timers.Add(timer);
            }
        }

        private IFlyingSaucerPresenter CreateFlyingSaucer()
        {
            var flyingSaucerPresenter = _factory.Create();
            var rotation = GetRotation();
            var position = _spawnerHelper.CalculatePosition(rotation);

            flyingSaucerPresenter.Init(position, _shipPresenter);
            flyingSaucerPresenter.Enable();

            _positionCheckService.AddDamagable(flyingSaucerPresenter);

            return flyingSaucerPresenter;
        }

        private void DestroyFlyingSaucer(IFlyingSaucerPresenter flyingSaucerPresenter)
        {
            flyingSaucerPresenter.Disable();

            _flyingSaucers.Remove(flyingSaucerPresenter);
            _positionCheckService.RemoveDamagable(flyingSaucerPresenter);
            _flyingSaucers.Remove(flyingSaucerPresenter);
            _factory.Release(flyingSaucerPresenter);

            FlyingSaucerDestroyed.SafeInvoke();
        }

        private void OnElapsed(ITimer timer)
        {
            timer.Elapsed -= OnElapsed;

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
                timer.Elapsed -= OnElapsed;

                _timers.Remove(timer);
                _timerService.RemoveTimer(timer);

                timer.Destroy();
            }
        }

        private void DestroyFlyingSaucers()
        {
            for (int i = _flyingSaucers.Count - 1; i >= 0; i--)
                DestroyFlyingSaucer(_flyingSaucers[i]);

            _flyingSaucers.Clear();
        }
    }
}
