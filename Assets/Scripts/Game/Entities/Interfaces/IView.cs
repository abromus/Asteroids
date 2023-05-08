using Asteroids.Core;

namespace Asteroids.Game
{
    public interface IView
    {
        public void Activate();

        public void Deactivate();

        public void Move(Float3 value);

        public void Rotate(Float3 value);
    }
}
