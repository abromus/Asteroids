using Asteroids.Core;

namespace Asteroids.Game
{
    public interface IFlyingSaucerPresenter : IPresenter, IPoolable, IDamagable
    {
        public void Init(Float3 position, IShipPresenter shipPresenter);
    }
}
