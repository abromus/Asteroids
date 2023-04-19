using Asteroids.Core;

namespace Asteroids.Game
{
    public interface IAsteroidPresenter : IPresenter, IPoolable, IDamagable
    {
        public bool IsDestroyed { get; }

        public void Init(Float3 position);
    }
}
