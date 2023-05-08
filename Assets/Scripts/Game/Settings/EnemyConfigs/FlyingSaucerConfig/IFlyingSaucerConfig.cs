using Asteroids.Core.Settings;

namespace Asteroids.Game.Settings
{
    public interface IFlyingSaucerConfig : IConfig
    {
        public float Speed { get; }
    }
}
