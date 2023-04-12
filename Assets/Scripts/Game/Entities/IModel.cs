using Asteroids.Core;

namespace Asteroids.Game
{
    public interface IModel
    {
        public IReactiveProperty<Float3> Position { get; set; }

        public IReactiveProperty<Float3> Rotation { get; set; }
    }
}
