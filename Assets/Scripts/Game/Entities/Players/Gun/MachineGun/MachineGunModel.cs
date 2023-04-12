using Asteroids.Core;

namespace Asteroids.Game
{
    public sealed class MachineGunModel : IMachineGunModel
    {
        public IReactiveProperty<Float3> Position { get; set; } = new ReactiveProperty<Float3>();

        public IReactiveProperty<Float3> Rotation { get; set; } = new ReactiveProperty<Float3>();
    }
}