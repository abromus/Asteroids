using Asteroids.Core;
using Asteroids.Core.Services;
using Asteroids.Game.Settings;

namespace Asteroids.Game.Factory
{
    public sealed class BulletFactory : IBulletFactory
    {
        private readonly IUpdater _updater;
        private readonly IBulletViewFactory _viewFactory;
        private readonly IBulletConfig _config;

        private readonly IObjectPool<IBulletPresenter> _pool;

        public BulletFactory(IUpdater updater, IBulletViewFactory viewFactory, IBulletConfig config)
        {
            _updater = updater;
            _viewFactory = viewFactory;
            _config = config;

            _pool = new ObjectPool<IBulletPresenter>(() => CreateBullet());
        }

        public IBulletPresenter Create()
        {
            var bullet = _pool.Get();

            return bullet;
        }

        public void Release(IBulletPresenter presenter)
        {
            presenter.Clear();

            _pool.Release(presenter);
        }

        private IBulletPresenter CreateBullet()
        {
            var model = new BulletModel();
            var view = _viewFactory.Create();
            var presenter = new BulletPresenter(_updater, model, view, _config);

            return presenter;
        }
    }
}
