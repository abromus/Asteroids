using Asteroids.Core;
using Asteroids.Core.Services;
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
        private readonly IObjectPool<IAsteroidFragmentPresenter> _fragmentPool;

        public AsteroidFactory(IUpdater updater, IAsteroidViewFactory viewFactory, IAsteroidConfig config, Bounds bounds)
        {
            _updater = updater;
            _viewFactory = viewFactory;
            _config = config;
            _bounds = bounds;

            _pool = new ObjectPool<IAsteroidPresenter>(() => CreateAsteroid());
            _fragmentPool = new ObjectPool<IAsteroidFragmentPresenter>(() => CreateAsteroidFragment());
        }

        public IAsteroidPresenter Create()
        {
            var asteroid = _pool.Get();

            return asteroid;
        }

        public IAsteroidFragmentPresenter CreateFragment()
        {
            var asteroidFragment = _fragmentPool.Get();

            return asteroidFragment;
        }

        public void Release(IAsteroidPresenter presenter)
        {
            presenter.Clear();

            _pool.Release(presenter);
        }

        public void ReleaseFragment(IAsteroidFragmentPresenter presenter)
        {
            presenter.Clear();

            _fragmentPool.Release(presenter);
        }

        private IAsteroidPresenter CreateAsteroid()
        {
            var model = new AsteroidModel();
            var view = _viewFactory.Create();
            var presenter = new AsteroidPresenter(_updater, model, view, _config, _bounds);

            return presenter;
        }

        private IAsteroidFragmentPresenter CreateAsteroidFragment()
        {
            var model = new AsteroidFragmentModel();
            var view = _viewFactory.CreateFragment();
            var presenter = new AsteroidFragmentPresenter(_updater, model, view, _config, _bounds);

            return presenter;
        }
    }
}
