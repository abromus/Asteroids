using Asteroids.Core;
using Asteroids.Core.Services;
using Asteroids.Game.Settings;

namespace Asteroids.Game.Factory
{
    public sealed class FlyingSaucerFactory : IFlyingSaucerFactory
    {
        private readonly IUpdater _updater;
        private readonly IFlyingSaucerViewFactory _viewFactory;
        private readonly IFlyingSaucerConfig _config;
        private readonly Bounds _bounds;

        private readonly IObjectPool<IFlyingSaucerPresenter> _pool;

        public FlyingSaucerFactory(IUpdater updater, IFlyingSaucerViewFactory viewFactory, IFlyingSaucerConfig config, Bounds bounds)
        {
            _updater = updater;
            _viewFactory = viewFactory;
            _config = config;
            _bounds = bounds;

            _pool = new ObjectPool<IFlyingSaucerPresenter>(() => CreateFlyingSaucer());
        }

        public IFlyingSaucerPresenter Create()
        {
            var flyingSaucer = _pool.Get();

            return flyingSaucer;
        }

        public void Destroy()
        {
            _pool.Dispose();
        }

        public void Release(IFlyingSaucerPresenter presenter)
        {
            presenter.Clear();

            _pool.Release(presenter);
        }

        private IFlyingSaucerPresenter CreateFlyingSaucer()
        {
            var model = new FlyingSaucerModel();
            var view = _viewFactory.Create();
            var presenter = new FlyingSaucerPresenter(_updater, model, view, _config, _bounds);

            return presenter;
        }
    }
}
