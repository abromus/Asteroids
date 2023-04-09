using Asteroids.Game.Settings;

namespace Asteroids.Game.Factory
{
    public sealed class BulletFactory : IBulletFactory
    {
        private readonly IUpdater _updater;
        private readonly IBulletViewFactory _viewFactory;
        private readonly IBulletConfig _config;

        public BulletFactory(IUpdater updater, IBulletViewFactory viewFactory, IBulletConfig config)
        {
            _updater = updater;
            _viewFactory = viewFactory;
            _config = config;
        }

        public IBulletPresenter Create()
        {
            var model = new BulletModel();
            var view = _viewFactory.Create();
            var presenter = new BulletPresenter(_updater, model, view, _config);

            return presenter;
        }
    }
}
