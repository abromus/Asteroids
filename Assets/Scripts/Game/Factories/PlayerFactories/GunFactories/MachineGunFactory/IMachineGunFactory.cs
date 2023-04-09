using Asteroids.Core.Factories;

namespace Asteroids.Game.Factory
{
    public interface IMachineGunFactory : IFactory
    {
        public IMachineGunPresenter Create();
    }
}
