using Asteroids.Core;

namespace Asteroids.Game
{
    public interface IBulletPresenter : IPresenter, IPoolable, IDamaging
    {
        public bool IsDestroyed { get; }

        public void SetPosition(Float3 position);

        public void SetRotation(Float3 rotation);
    }
}
