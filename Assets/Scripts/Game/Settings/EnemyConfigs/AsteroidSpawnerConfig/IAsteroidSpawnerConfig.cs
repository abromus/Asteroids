using Asteroids.Core.Settings;

namespace Asteroids.Game.Settings
{
    public interface IAsteroidSpawnerConfig : IConfig
    {
        public int MaxCount { get; }

        public float SpawnDelay { get; }
    }
}
