using UnityEngine;

namespace Asteroids.Game.Settings
{
    [CreateAssetMenu(fileName = "ConfigData", menuName = "Settings/Game/ConfigData")]
    public sealed class ConfigData : ScriptableObject, IConfigData
    {
        [SerializeField] private AsteroidConfig _asteroidConfig;
        [SerializeField] private BulletConfig _bulletConfig;
        [SerializeField] private FlyingSaucerConfig _flyingSaucerConfig;
        [SerializeField] private InputConfig _inputConfig;
        [SerializeField] private MachineGunConfig _machineGunConfig;
        [SerializeField] private ShipConfig _shipConfig;

        public IAsteroidConfig AsteroidConfig => _asteroidConfig;

        public IBulletConfig BulletConfig => _bulletConfig;

        public IFlyingSaucerConfig FlyingSaucerConfig => _flyingSaucerConfig;

        public IInputConfig InputConfig => _inputConfig;

        public IMachineGunConfig MachineGunConfig => _machineGunConfig;

        public IShipConfig ShipConfig => _shipConfig;
    }
}
