using Asteroids.Core;

namespace Asteroids.Game
{
    public sealed class BulletView : View, IBulletView
    {
        public void Init() { }

        public void Move(Float3 value)
        {
            transform.Translate(value.ToVector3());
        }

        public void Move(Float2 value)
        {
            transform.Translate(value.ToVector2());
        }

        public void Rotate(Float3 value)
        {
            transform.Rotate(value.ToVector3());
        }
    }
}
