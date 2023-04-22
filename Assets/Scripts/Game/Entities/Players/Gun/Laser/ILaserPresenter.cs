using Asteroids.Core;

namespace Asteroids.Game
{
    public interface ILaserPresenter : IPresenter, IPoolable, IDamaging
    {
        public void SetPosition(Float3 position);

        public void SetRotation(Float3 rotation);
    }
}
