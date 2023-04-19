using Asteroids.Core;
using Asteroids.Game.Settings;

namespace Asteroids.Game.Factory
{
    public sealed class AsteroidFactory : IAsteroidFactory
    {
        private readonly IUpdater _updater;
        private readonly IAsteroidViewFactory _viewFactory;
        private readonly IAsteroidConfig _config;
        private readonly Bounds _bounds;

        private readonly IObjectPool<IAsteroidPresenter> _pool;

        public AsteroidFactory(IUpdater updater, IAsteroidViewFactory viewFactory, IAsteroidConfig config, Bounds bounds)
        {
            _updater = updater;
            _viewFactory = viewFactory;
            _config = config;
            _bounds = bounds;

            _pool = new ObjectPool<IAsteroidPresenter>(() => CreateAsteroid());
        }

        public IAsteroidPresenter Create()
        {
            var asteroid = _pool.Get();

            return asteroid;
        }

        public void Release(IAsteroidPresenter presenter)
        {
            presenter.Clear();

            _pool.Release(presenter);
        }

        private IAsteroidPresenter CreateAsteroid()
        {
            var model = new AsteroidModel();
            var view = _viewFactory.Create();
            var presenter = new AsteroidPresenter(_updater, model, view, _config, _bounds);

            return presenter;
        }
    }
}
