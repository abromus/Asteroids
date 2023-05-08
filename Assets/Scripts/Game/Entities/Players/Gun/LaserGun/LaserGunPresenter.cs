using System.Collections.Generic;
using Asteroids.Core;
using Asteroids.Core.Services;
using Asteroids.Game.Factory;
using Asteroids.Game.Services;
using Asteroids.Game.Settings;

namespace Asteroids.Game
{
    public sealed class LaserGunPresenter : ILaserGunPresenter
    {
        private Float3 _offset;
        private int _currentLasers;

        private readonly IUpdater _updater;
        private readonly ITimerService _timerService;
        private readonly IPositionCheckService _positionCheckService;
        private readonly ILaserGunModel _model;
        private readonly ILaserGunView _view;
        private readonly ILaserGunConfig _config;
        private readonly ILaserFactory _laserFactory;

        private readonly List<ILaserPresenter> _lasers;
        private readonly ITimer _firingTimer;
        private readonly float _firingDelay;

        private readonly ILaserGunReloader _laserGunReloader;

        public int LasersCount => _laserGunReloader.IsReload ? (int)MathUtils.Zero : _currentLasers;

        public float ReloadTime => _laserGunReloader.ReloadTime;

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
            _firingDelay = MathUtils.Inverse(_config.FiringRate);

            _laserGunReloader = new LaserGunReloader(_timerService, _config.ReloadTime, _config.RegenerateTime);
            _laserGunReloader.Reloaded += OnReloaded;
            _laserGunReloader.Regenerated += OnRegenerated;
        }

        public void Enable()
        {
            _updater.Add(this);

            _firingTimer?.Resume();
            _laserGunReloader.Enable();
        }

        public void Disable()
        {
            _updater.Remove(this);

            _firingTimer?.Pause();
            _laserGunReloader.Disable();
        }

        public void Destroy()
        {
            Disable();

            _timerService.RemoveTimer(_firingTimer);

            _laserGunReloader.Destroy();
            _laserGunReloader.Reloaded = null;
            _laserGunReloader.Regenerated = null;

            foreach (var laser in _lasers)
                DestroyLaser(laser);
        }

        public void Tick(float deltaTime)
        {
            for (int i = _lasers.Count - 1; i >= 0; i--)
            {
                var laser = _lasers[i];

                if (!laser.IsDestroyed)
                    continue;

                DestroyLaser(laser);

                _lasers.RemoveAt(i);
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
            if (_currentLasers <= MathUtils.Zero && !_laserGunReloader.IsReload)
                _laserGunReloader.Reload();

            if (!CanShoot())
                return;

            Shoot();
        }

        private bool CanShoot()
        {
            return !(_laserGunReloader.IsReload || _currentLasers <= MathUtils.Zero || _firingTimer == null || !_firingTimer.IsElapsed);
        }

        private void Shoot()
        {
            UpdateTimer();

            CreateLaser();

            _laserGunReloader.RegenerateLaser();
        }

        private void CreateLaser()
        {
            var laser = _laserFactory.Create();
            laser.SetRotation(_model.Rotation.Value);
            laser.SetPosition(_model.Position.Value);
            laser.Enable();

            _positionCheckService.AddDamaging(laser);

            _lasers.Add(laser);
            _currentLasers--;
        }

        private void DestroyLaser(ILaserPresenter laser)
        {
            _laserFactory.Release(laser);

            _positionCheckService.RemoveDamaging(laser);
        }

        private ITimer CreateTimer()
        {
            var timer = _timerService.CreateTimer();
            timer.Pause();

            return timer;
        }

        private void UpdateTimer()
        {
            _firingTimer.UpdateTime(_firingDelay);
            _firingTimer.Resume();
        }

        private void OnReloaded()
        {
            _currentLasers = _config.Capacity;
        }

        private void OnRegenerated()
        {
            if (!_laserGunReloader.IsReload)
                _currentLasers++;

            if (_currentLasers >= _config.Capacity)
                _laserGunReloader.StopRegeneration();
        }
    }
}
