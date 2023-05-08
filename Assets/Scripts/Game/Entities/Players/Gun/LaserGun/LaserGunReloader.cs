using System;
using Asteroids.Core;
using Asteroids.Game.Services;

namespace Asteroids.Game
{
    public class LaserGunReloader : ILaserGunReloader
    {
        private bool _isReload;
        private bool _canRegeneration;

        private readonly ITimerService _timerService;
        private readonly float _reloadTime;
        private readonly float _regenerateTime;

        private readonly ITimer _reloadTimer;
        private readonly ITimer _regenerateTimer;

        public bool IsReload => _isReload;

        public float ReloadTime => _isReload ? _reloadTimer.TimeLeft : _regenerateTimer.TimeLeft;

        public Action Reloaded { get; set; }

        public Action Regenerated { get; set; }

        public LaserGunReloader(ITimerService timerService, float reloadTime, float regenerateTime)
        {
            _timerService = timerService;
            _reloadTime = reloadTime;
            _regenerateTime = regenerateTime;

            _reloadTimer = CreateTimer();
            _regenerateTimer = CreateTimer();

            _canRegeneration = true;
        }

        public void Enable()
        {
            _reloadTimer?.Resume();
            _regenerateTimer?.Resume();
        }

        public void Disable()
        {
            _reloadTimer?.Pause();
            _regenerateTimer?.Pause();
        }

        public void Destroy()
        {
            _timerService.RemoveTimer(_reloadTimer);
            _timerService.RemoveTimer(_regenerateTimer);
        }

        public void Reload()
        {
            _isReload = true;
            _canRegeneration = true;

            StopRegenerateTimer();
            UpdateReloadTimer();
        }

        public void StopRegeneration()
        {
            _canRegeneration = false;
        }

        public void RegenerateLaser()
        {
            if (_regenerateTimer.IsElapsed)
                _regenerateTimer.Elapsed += AfterRegenerateLaser;

            _regenerateTimer.UpdateTime(_regenerateTime);
            _regenerateTimer.Resume();
        }

        private void AfterRegenerateLaser(ITimer timer)
        {
            timer.Elapsed -= AfterRegenerateLaser;

            Regenerated.SafeInvoke();

            if (!_canRegeneration)
            {
                _canRegeneration = true;
                return;
            }

            RegenerateLaser();
        }

        private void AfterReload(ITimer timer)
        {
            timer.Elapsed -= AfterReload;
            _isReload = false;

            Reloaded.SafeInvoke();
        }

        private ITimer CreateTimer()
        {
            var timer = _timerService.CreateTimer();
            timer.Pause();

            return timer;
        }

        private void StopRegenerateTimer()
        {
            _regenerateTimer.Elapsed -= AfterRegenerateLaser;
            _regenerateTimer.UpdateTime(MathUtils.Zero);
            _regenerateTimer.Pause();
        }

        private void UpdateReloadTimer()
        {
            _reloadTimer.UpdateTime(_reloadTime);
            _reloadTimer.Resume();
            _reloadTimer.Elapsed += AfterReload;
        }
    }
}
