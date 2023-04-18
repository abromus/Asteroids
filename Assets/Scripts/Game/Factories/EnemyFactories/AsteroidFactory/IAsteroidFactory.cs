using Asteroids.Core.Factories;

namespace Asteroids.Game.Factory
{
    public interface IAsteroidFactory : IFactory
    {
        public IAsteroidPresenter Create();

        public void Release(IAsteroidPresenter presenter);
    }
}
