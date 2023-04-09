using Asteroids.Game.Settings;

namespace Asteroids.Game.Factory
{
    public sealed class AsteroidFactory : IAsteroidFactory
    {
        private readonly IUpdater _updater;
        private readonly IAsteroidViewFactory _viewFactory;
        private readonly IAsteroidConfig _config;

        public AsteroidFactory(IUpdater updater, IAsteroidViewFactory viewFactory, IAsteroidConfig config)
        {
            _updater = updater;
            _viewFactory = viewFactory;
            _config = config;
        }

        public IAsteroidPresenter Create()
        {
            var model = new AsteroidModel();
            var view = _viewFactory.Create();
            var presenter = new AsteroidPresenter(_updater, model, view, _config);

            return presenter;
        }
    }
}
