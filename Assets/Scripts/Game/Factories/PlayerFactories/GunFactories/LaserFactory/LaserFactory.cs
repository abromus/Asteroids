using Asteroids.Core;
using Asteroids.Core.Services;
using Asteroids.Game.Settings;

namespace Asteroids.Game.Factory
{
    public sealed class LaserFactory : ILaserFactory
    {
        private readonly IUpdater _updater;
        private readonly ILaserViewFactory _viewFactory;
        private readonly ILaserConfig _config;

        private readonly IObjectPool<ILaserPresenter> _pool;

        public LaserFactory(IUpdater updater, ILaserViewFactory viewFactory, ILaserConfig config)
        {
            _updater = updater;
            _viewFactory = viewFactory;
            _config = config;

            _pool = new ObjectPool<ILaserPresenter>(() => CreateLaser());
        }

        public ILaserPresenter Create()
        {
            var laser = _pool.Get();

            return laser;
        }

        public void Release(ILaserPresenter presenter)
        {
            presenter.Clear();

            _pool.Release(presenter);
        }

        private ILaserPresenter CreateLaser()
        {
            var model = new LaserModel();
            var view = _viewFactory.Create();
            var presenter = new LaserPresenter(_updater, model, view, _config);

            return presenter;
        }
    }
}
