using Asteroids.Core.Settings;

namespace Asteroids.Game.Settings
{
    public interface IShipConfig : IConfig
    {
        public float AngularVelocity { get; }

        public float Speed { get; }
    }
}
