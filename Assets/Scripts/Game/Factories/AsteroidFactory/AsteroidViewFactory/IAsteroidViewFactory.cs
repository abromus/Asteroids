using Asteroids.Core.Factories;

namespace Asteroids.Game.Factory
{
    public interface IAsteroidViewFactory : IFactory
    {
        public AsteroidView Create();
    }
}
