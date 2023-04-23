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
        private readonly ITimer _firingTimer;
        private readonly ITimer _reloadTimer;
        private readonly ITimer _regenerateTimer;

        private Float3 _offset;
        private int _currentLasers;
        private bool _isReload;

        public int LasersCount => _isReload ? (int)MathUtils.Zero : _currentLasers;

        public float ReloadTime => _isReload ? _reloadTimer.TimeLeft : _regenerateTimer.TimeLeft;

        public Float3 Offset => _offset;

        public Float3 Position => _model.Position.Value;

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
            _currentLasers = _config.Capacity;

            _firingTimer = CreateTimer();
            _reloadTimer = CreateTimer();
            _regenerateTimer = CreateTimer();
        }

        public void Enable()
        {
            _updater.Add(this);

            _firingTimer?.Resume();
            _reloadTimer?.Resume();
            _regenerateTimer?.Resume();
        }

        public void Destroy()
        {
            Disable();

            _timerService.RemoveTimer(_firingTimer);
            _timerService.RemoveTimer(_reloadTimer);
            _timerService.RemoveTimer(_regenerateTimer);
        }

        public void Disable()
        {
            _updater.Remove(this);

            _firingTimer?.Pause();
            _reloadTimer?.Pause();
            _regenerateTimer?.Pause();
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
            if (_currentLasers <= MathUtils.Zero && !_isReload)
                Reload();

            if (!CanShoot())
                return;

            Shoot();
        }

        private ITimer CreateTimer()
        {
            var timer = _timerService.CreateTimer();
            timer.Pause();

            return timer;
        }

        private bool CanShoot()
        {
            return !(_isReload || _currentLasers <= MathUtils.Zero || _firingTimer == null || !_firingTimer.IsElapsed);
        }

        private void Reload()
        {
            _isReload = true;

            _regenerateTimer.Elapsed -= AfterRegenerateLaser;
            _regenerateTimer.UpdateTime(MathUtils.Zero);
            _regenerateTimer.Pause();

            _reloadTimer.UpdateTime(_config.ReloadTime);
            _reloadTimer.Resume();
            _reloadTimer.Elapsed += AfterReload;
        }

        private void AfterReload(ITimer timer)
        {
            timer.Elapsed -= AfterReload;
            _currentLasers = _config.Capacity;
            _isReload = false;
        }

        private void Shoot()
        {
            var firingDelay = MathUtils.Inverse(_config.FiringRate);

            _firingTimer.UpdateTime(firingDelay);
            _firingTimer.Resume();

            var laser = _laserFactory.Create();
            laser.SetRotation(_model.Rotation.Value);
            laser.SetPosition(_model.Position.Value);
            laser.Enable();

            _positionCheckService.AddDamaging(laser);

            _lasers.Add(laser);
            _currentLasers--;

            RegenerateLaser();
        }

        private void RegenerateLaser()
        {
            if (_regenerateTimer.IsElapsed)
                _regenerateTimer.Elapsed += AfterRegenerateLaser;

            _regenerateTimer.UpdateTime(_config.RegenerateTime);
            _regenerateTimer.Resume();
        }

        private void AfterRegenerateLaser(ITimer timer)
        {
            timer.Elapsed -= AfterRegenerateLaser;

            if (!_isReload)
                _currentLasers++;

            if (_currentLasers >= _config.Capacity)
                return;

            RegenerateLaser();
        }
    }
}
