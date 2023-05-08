using Asteroids.Core.Settings;

namespace Asteroids.Game.Settings
{
    public interface IAsteroidConfig : IConfig
    {
        public float FragmentSpeed { get; }

        public float Speed { get; }
    }
}
