namespace Asteroids.Game.Settings
{
    public interface IConfigData
    {
        public IAsteroidConfig AsteroidConfig { get; }

        public IBulletConfig BulletConfig { get; }

        public IFlyingSaucerConfig FlyingSaucerConfig { get; }

        public IInputConfig InputConfig { get; }

        public IShipConfig ShipConfig { get; }
    }
}
