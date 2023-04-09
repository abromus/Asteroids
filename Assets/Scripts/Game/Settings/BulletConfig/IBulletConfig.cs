using Asteroids.Core.Settings;

namespace Asteroids.Game.Settings
{
    public interface IBulletConfig : IConfig
    {
        public float Speed { get; }
    }
}
