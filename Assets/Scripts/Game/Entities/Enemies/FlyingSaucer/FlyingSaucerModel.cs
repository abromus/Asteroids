using Asteroids.Core;

namespace Asteroids.Game
{
    public sealed class FlyingSaucerModel : IFlyingSaucerModel
    {
        public IReactiveProperty<Float3> Position { get; set; } = new ReactiveProperty<Float3>();

        public IReactiveProperty<Float3> Rotation { get; set; } = new ReactiveProperty<Float3>();
    }
}
