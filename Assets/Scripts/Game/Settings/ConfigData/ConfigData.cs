using UnityEngine;

namespace Asteroids.Game.Settings
{
    [CreateAssetMenu(fileName = nameof(ConfigData), menuName = ConfigKeys.GamePathKey + nameof(ConfigData))]
    public sealed class ConfigData : ScriptableObject, IConfigData
    {
        [SerializeField] private AsteroidConfig _asteroidConfig;
        [SerializeField] private AsteroidSpawnerConfig _asteroidSpawnerConfig;
        [SerializeField] private BulletConfig _bulletConfig;
        [SerializeField] private FlyingSaucerConfig _flyingSaucerConfig;
        [SerializeField] private FlyingSaucerSpawnerConfig _flyingSaucerSpawnerConfig;
        [SerializeField] private InputConfig _inputConfig;
        [SerializeField] private LaserConfig _laserConfig;
        [SerializeField] private LaserGunConfig _laserGunConfig;
        [SerializeField] private MachineGunConfig _machineGunConfig;
        [SerializeField] private ShipConfig _shipConfig;

        public IAsteroidConfig AsteroidConfig => _asteroidConfig;

        public IAsteroidSpawnerConfig AsteroidSpawnerConfig => _asteroidSpawnerConfig;

        public IBulletConfig BulletConfig => _bulletConfig;

        public IFlyingSaucerConfig FlyingSaucerConfig => _flyingSaucerConfig;

        public IFlyingSaucerSpawnerConfig FlyingSaucerSpawnerConfig => _flyingSaucerSpawnerConfig;

        public IInputConfig InputConfig => _inputConfig;

        public ILaserConfig LaserConfig => _laserConfig;

        public ILaserGunConfig LaserGunConfig => _laserGunConfig;

        public IMachineGunConfig MachineGunConfig => _machineGunConfig;

        public IShipConfig ShipConfig => _shipConfig;
    }
}
