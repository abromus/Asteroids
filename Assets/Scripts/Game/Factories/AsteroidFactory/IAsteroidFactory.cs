using Asteroids.Core.Factories;

namespace Asteroids.Game.Factory
{
    public interface IAsteroidFactory : IFactory
    {
        public AsteroidPresenter Create();
    }
}
