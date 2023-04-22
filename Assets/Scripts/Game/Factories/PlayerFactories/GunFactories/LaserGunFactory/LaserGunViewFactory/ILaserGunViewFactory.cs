using Asteroids.Core.Factories;

namespace Asteroids.Game.Factory
{
    public interface ILaserGunViewFactory : IFactory
    {
        public ILaserGunView Create();
    }
}
