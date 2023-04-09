using Asteroids.Core.Factories;

namespace Asteroids.Game.Factory
{
    public interface IMachineGunViewFactory : IFactory
    {
        public IMachineGunView Create();
    }
}
