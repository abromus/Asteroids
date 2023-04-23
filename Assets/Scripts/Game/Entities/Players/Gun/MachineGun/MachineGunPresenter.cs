using System.Collections.Generic;
using Asteroids.Core;
using Asteroids.Game.Factory;
using Asteroids.Game.Services;
using Asteroids.Game.Settings;

namespace Asteroids.Game
{
    public sealed class MachineGunPresenter : IMachineGunPresenter
    {
        private readonly IUpdater _updater;
        private readonly ITimerService _timerService;
        private readonly IPositionCheckService _positionCheckService;
        private readonly IMachineGunModel _model;
        private readonly IMachineGunView _view;
        private readonly IMachineGunConfig _config;
        private readonly IBulletFactory _bulletFactory;

        private readonly List<IBulletPresenter> _bullets;
        private readonly ITimer _timer;

        private Float3 _offset;

        public Float3 Position => _model.Position.Value;

        public Float3 Offset => _offset;

        public IMachineGunView View => _view;

        public MachineGunPresenter(
            IUpdater updater,
            ITimerService timerService,
            IPositionCheckService positionCheckService,
            IMachineGunModel model,
            IMachineGunView view,
            IMachineGunConfig config,
            IBulletFactory bulletFactory)
        {
            _updater = updater;
            _timerService = timerService;
            _positionCheckService = positionCheckService;
            _model = model;
            _view = view;
            _config = config;
            _bulletFactory = bulletFactory;

            _offset = _config.Offset.ToFloat3();
            _bullets = new List<IBulletPresenter>();

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
            for (int i = 0; i < _bullets.Count; i++)
            {
                var bullet = _bullets[i];

                if (bullet.IsDestroyed)
                {
                    _bullets.RemoveAt(i);
                    _bulletFactory.Release(bullet);

                    _positionCheckService.RemoveDamaging(bullet);
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
            _timer.Resume();

            var bullet = _bulletFactory.Create();
            bullet.SetRotation(_model.Rotation.Value);
            bullet.SetPosition(_model.Position.Value);
            bullet.Enable();

            _positionCheckService.AddDamaging(bullet);

            _bullets.Add(bullet);
        }
    }
}
