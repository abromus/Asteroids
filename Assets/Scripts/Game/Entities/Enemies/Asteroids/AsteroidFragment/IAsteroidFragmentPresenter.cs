using Asteroids.Core;

namespace Asteroids.Game
{
    public interface IAsteroidFragmentPresenter : IPresenter, IPoolable, IDamagable
    {
        public void Init(Float3 position);
    }
}
