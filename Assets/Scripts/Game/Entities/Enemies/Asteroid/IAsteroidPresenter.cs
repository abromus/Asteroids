using Asteroids.Core;

namespace Asteroids.Game
{
    public interface IAsteroidPresenter : IPresenter, IPoolable
    {
        public void Init(Float3 position);
    }
}
