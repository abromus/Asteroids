using Asteroids.Core;

namespace Asteroids.Game
{
    public interface IBulletPresenter : IPresenter
    {
        public void SetPosition(Float3 position);

        public void SetRotate(Float3 rotation);
    }
}
