using Asteroids.Core.Factories;

namespace Asteroids.Game.Factory
{
    public interface ILaserViewFactory : IFactory
    {
        public ILaserView Create();
    }
}
