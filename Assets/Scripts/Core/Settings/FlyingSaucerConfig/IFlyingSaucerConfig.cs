namespace Asteroids.Core.Settings
{
    public interface IFlyingSaucerConfig : IConfig
    {
        public float Damping { get; }

        public float Speed { get; }
    }
}
