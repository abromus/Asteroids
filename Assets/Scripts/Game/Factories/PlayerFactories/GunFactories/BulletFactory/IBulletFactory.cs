using Asteroids.Core.Factories;

namespace Asteroids.Game.Factory
{
    public interface IBulletFactory : IFactory
    {
        public IBulletPresenter Create();
    }
}
