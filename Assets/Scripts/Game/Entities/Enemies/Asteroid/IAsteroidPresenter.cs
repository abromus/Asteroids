using Asteroids.Core;

namespace Asteroids.Game
{
    public interface IAsteroidPresenter : IPresenter, IPoolable, IDamagable
    {
        public void Init(Float3 position);
    }
}
