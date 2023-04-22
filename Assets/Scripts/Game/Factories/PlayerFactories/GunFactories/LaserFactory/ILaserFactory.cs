using Asteroids.Core.Factories;

namespace Asteroids.Game.Factory
{
    public interface ILaserFactory : IFactory
    {
        public ILaserPresenter Create();

        public void Release(ILaserPresenter presenter);
    }
}
