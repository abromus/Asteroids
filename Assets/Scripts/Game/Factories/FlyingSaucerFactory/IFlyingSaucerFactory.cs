using Asteroids.Core.Factories;

namespace Asteroids.Game.Factory
{
    public interface IFlyingSaucerFactory : IFactory
    {
        public FlyingSaucerPresenter Create();
    }
}
