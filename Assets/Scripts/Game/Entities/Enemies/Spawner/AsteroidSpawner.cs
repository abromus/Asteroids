using Asteroids.Core;
using Asteroids.Game.Factory;

namespace Asteroids.Game
{
    public sealed class AsteroidSpawner : IAsteroidSpawner<IAsteroidPresenter>
    {
        private readonly IAsteroidFactory _factory;

        public AsteroidSpawner(IAsteroidFactory factory)
        {
            _factory = factory;
        }

        public IAsteroidPresenter Spawn()
        {
            return CreateAsteroids();
        }

        private IAsteroidPresenter CreateAsteroids()
        {
            var asteroidPresenter = _factory.Create();

            var position = Float3.Zero;
            asteroidPresenter.Init(position);

            asteroidPresenter.Enable();

            return asteroidPresenter;
        }
    }
}
