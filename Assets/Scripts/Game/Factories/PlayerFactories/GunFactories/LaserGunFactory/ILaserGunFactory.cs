using Asteroids.Core.Factories;

namespace Asteroids.Game.Factory
{
    public interface ILaserGunFactory : IFactory
    {
        public ILaserGunPresenter Create();
    }
}
