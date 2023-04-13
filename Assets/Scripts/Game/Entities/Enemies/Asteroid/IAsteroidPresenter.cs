using Asteroids.Core;

namespace Asteroids.Game
{
    public interface IAsteroidPresenter : IPresenter
    {
        public void Init(Float3 position);
    }
}
