using Asteroids.Core.Settings;

namespace Asteroids.Game.Settings
{
    public interface IFlyingSaucerSpawnerConfig : IConfig
    {
        public int MaxCount { get; }

        public float SpawnDelay { get; }
    }
}
