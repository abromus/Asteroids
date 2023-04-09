using Asteroids.Core.Factories;

namespace Asteroids.Game.Factory
{
    public interface IBulletViewFactory : IFactory
    {
        public IBulletView Create();
    }
}
