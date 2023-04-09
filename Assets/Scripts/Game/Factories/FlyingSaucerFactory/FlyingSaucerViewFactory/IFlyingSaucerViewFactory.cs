using Asteroids.Core.Factories;

namespace Asteroids.Game.Factory
{
    public interface IFlyingSaucerViewFactory : IFactory
    {
        public FlyingSaucerView Create();
    }
}
