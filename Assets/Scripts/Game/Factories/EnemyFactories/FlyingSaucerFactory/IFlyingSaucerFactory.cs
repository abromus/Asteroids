using Asteroids.Core.Factories;

namespace Asteroids.Game.Factory
{
    public interface IFlyingSaucerFactory : IFactory
    {
        public IFlyingSaucerPresenter Create();

        public void Release(IFlyingSaucerPresenter presenter);
    }
}
