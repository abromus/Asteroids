using Asteroids.Core;

namespace Asteroids.Game
{
    public interface IPresenter : IUpdatable
    {
        public Float3 Position { get; }

        public void Destroy();

        public void Disable();

        public void Enable();
    }
}
