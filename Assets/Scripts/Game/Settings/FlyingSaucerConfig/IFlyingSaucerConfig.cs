using Asteroids.Core.Settings;

namespace Asteroids.Game.Settings
{
    public interface IFlyingSaucerConfig : IConfig
    {
        public float Damping { get; }

        public float Speed { get; }
    }
}
