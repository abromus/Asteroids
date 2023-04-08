namespace Asteroids.Core.Settings
{
    public interface IShipConfig : IConfig
    {
        public float Damping { get; }

        public float Speed { get; }
    }
}
