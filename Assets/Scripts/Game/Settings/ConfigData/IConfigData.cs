namespace Asteroids.Game.Settings
{
    public interface IConfigData
    {
        public IAsteroidConfig AsteroidConfig { get; }

        public IAsteroidSpawnerConfig AsteroidSpawnerConfig { get; }

        public IBulletConfig BulletConfig { get; }

        public IFlyingSaucerConfig FlyingSaucerConfig { get; }

        public IFlyingSaucerSpawnerConfig FlyingSaucerSpawnerConfig { get; }

        public IInputConfig InputConfig { get; }

        public ILaserConfig LaserConfig { get; }

        public ILaserGunConfig LaserGunConfig { get; }

        public IMachineGunConfig MachineGunConfig { get; }

        public IShipConfig ShipConfig { get; }
    }
}
