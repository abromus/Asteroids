using Asteroids.Core.Factories;

namespace Asteroids.Game.Factory
{
    public interface IAsteroidFactory : IFactory
    {
        public IAsteroidPresenter Create();

        public IAsteroidFragmentPresenter CreateFragment();

        public void Release(IAsteroidPresenter presenter);

        public void ReleaseFragment(IAsteroidFragmentPresenter presenter);
    }
}
