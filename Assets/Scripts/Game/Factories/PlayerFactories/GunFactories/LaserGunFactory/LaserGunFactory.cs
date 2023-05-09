using Asteroids.Core.Services;
using Asteroids.Game.Services;
using Asteroids.Game.Settings;

namespace Asteroids.Game.Factory
{
    public sealed class LaserGunFactory : ILaserGunFactory
    {
        private readonly IUpdater _updater;
        private readonly ITimerService _timerService;
        private readonly IPositionCheckService _positionCheckService;
        private readonly ILaserGunViewFactory _viewFactory;
        private readonly ILaserGunConfig _config;
        private readonly ILaserFactory _laserFactory;

        public LaserGunFactory(
            IUpdater updater,
            ITimerService timerService,
            IPositionCheckService positionCheckService,
            ILaserGunViewFactory viewFactory,
            ILaserGunConfig config,
            ILaserFactory laserFactory)
        {
            _updater = updater;
            _timerService = timerService;
            _positionCheckService = positionCheckService;
            _viewFactory = viewFactory;
            _config = config;
            _laserFactory = laserFactory;
        }

        public void Destroy() { }

        public ILaserGunPresenter Create()
        {
            var model = new LaserGunModel();
            var view = _viewFactory.Create();
            var presenter = new LaserGunPresenter(
                _updater,
                _timerService,
                _positionCheckService,
                model,
                view,
                _config,
                _laserFactory);

            return presenter;
        }
    }
}
