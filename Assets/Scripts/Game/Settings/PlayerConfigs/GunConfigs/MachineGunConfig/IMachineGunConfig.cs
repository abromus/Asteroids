using Asteroids.Core.Settings;

namespace Asteroids.Game.Settings
{
    public interface IMachineGunConfig : IConfig
    {
        public float FiringRate { get; }
    }
}
