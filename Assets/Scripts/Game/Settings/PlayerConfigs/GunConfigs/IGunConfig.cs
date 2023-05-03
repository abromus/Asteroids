using Asteroids.Core.Settings;

namespace Asteroids.Game.Settings
{
    public interface IGunConfig : IConfig
    {
        public float MaxDistance { get; }

        public float Speed { get; }
    }
}
