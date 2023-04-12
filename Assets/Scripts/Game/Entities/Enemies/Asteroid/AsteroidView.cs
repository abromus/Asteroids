using Asteroids.Core;

namespace Asteroids.Game
{
    public sealed class AsteroidView : View, IAsteroidView
    {
        public void Init() { }

        public void Move(Float3 value)
        {
            transform.Translate(value.ToVector3());
        }

        public void Rotate(Float3 value)
        {
            transform.Rotate(value.ToVector3());
        }
    }
}
