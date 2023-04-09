namespace Asteroids.Core.Settings
{
    public interface IAsteroidConfig : IConfig
    {
        public float Damping { get; }

        public float Speed { get; }
    }
}
