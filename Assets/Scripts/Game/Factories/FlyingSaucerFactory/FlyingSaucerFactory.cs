using Asteroids.Core.Settings;

namespace Asteroids.Game.Factory
{
    public sealed class FlyingSaucerFactory : IFlyingSaucerFactory
    {
        private readonly IUpdater _updater;
        private readonly IFlyingSaucerViewFactory _viewFactory;
        private readonly IFlyingSaucerConfig _config;

        public FlyingSaucerFactory(IUpdater updater, IFlyingSaucerViewFactory viewFactory, IFlyingSaucerConfig config)
        {
            _updater = updater;
            _viewFactory = viewFactory;
            _config = config;
        }

        public FlyingSaucerPresenter Create()
        {
            var model = new FlyingSaucerModel();
            var view = _viewFactory.Create();
            var presenter = new FlyingSaucerPresenter(_updater, model, view, _config);

            return presenter;
        }
    }
}
