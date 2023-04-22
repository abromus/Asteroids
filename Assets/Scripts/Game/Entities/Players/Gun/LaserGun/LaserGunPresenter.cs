using System.Collections.Generic;
using Asteroids.Core;
using Asteroids.Game.Factory;
using Asteroids.Game.Services;
using Asteroids.Game.Settings;

namespace Asteroids.Game
{
    public sealed class LaserGunPresenter : ILaserGunPresenter
    {
        private readonly IUpdater _updater;
        private readonly ITimerService _timerService;
        private readonly IPositionCheckService _positionCheckService;
        private readonly ILaserGunModel _model;
        private readonly ILaserGunView _view;
        private readonly ILaserGunConfig _config;
        private readonly ILaserFactory _laserFactory;

        private readonly List<ILaserPresenter> _lasers;
        private readonly ITimer _timer;

        private Float3 _offset;

        public Float3 Position => _model.Position.Value;

        public Float3 Offset => _offset;

        public ILaserGunView View => _view;

        public LaserGunPresenter(
            IUpdater updater,
            ITimerService timerService,
            IPositionCheckService positionCheckService,
            ILaserGunModel model,
            ILaserGunView view,
            ILaserGunConfig config,
            ILaserFactory laserFactory)
        {
            _updater = updater;
            _timerService = timerService;
            _positionCheckService = positionCheckService;
            _model = model;
            _view = view;
            _config = config;
            _laserFactory = laserFactory;

            _offset = _config.Offset.ToFloat3();
            _lasers = new List<ILaserPresenter>();

            _timer = _timerService.CreateTimer();
        }

        public void Enable()
        {
            _updater.Add(this);

            _timer?.Resume();
        }

        public void Destroy()
        {
            Disable();

            _timerService.RemoveTimer(_timer);
        }

        public void Disable()
        {
            _updater.Remove(this);

            _timer?.Pause();
        }

        public void Tick(float deltaTime)
        {
            for (int i = 0; i < _lasers.Count; i++)
            {
                var laser = _lasers[i];

                if (laser.IsDestroyed)
                {
                    _lasers.RemoveAt(i);
                    _laserFactory.Release(laser);

                    _positionCheckService.RemoveDamaging(laser);
                    i--;
                }
            }
        }

        public void SetPosition(Float3 position)
        {
            _model.Position.Value = position + _offset;
        }

        public void SetRotation(Float3 rotation)
        {
            _model.Rotation.Value = rotation;
        }

        public void TryShoot()
        {
            if (_timer == null || !_timer.IsElapsed)
                return;

            var firingDelay = MathUtils.Inverse(_config.FiringRate);

            _timer.UpdateTime(firingDelay);

            var laser = _laserFactory.Create();
            laser.SetRotation(_model.Rotation.Value);
            laser.SetPosition(_model.Position.Value);
            laser.Enable();

            _positionCheckService.AddDamaging(laser);

            _lasers.Add(laser);
        }
    }
}
