using Asteroids.Core;

namespace Asteroids.Game
{
    public sealed class FlyingSaucerView : View, IFlyingSaucerView
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
