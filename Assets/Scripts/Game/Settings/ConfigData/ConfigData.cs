using UnityEngine;

namespace Asteroids.Game.Settings
{
    [CreateAssetMenu(fileName = "ConfigData", menuName = "Settings/ConfigData")]
    public sealed class ConfigData : ScriptableObject, IConfigData
    {
        [SerializeField] private AsteroidConfig _asteroidConfig;
        [SerializeField] private FlyingSaucerConfig _flyingSaucerConfig;
        [SerializeField] private InputConfig _inputConfig;
        [SerializeField] private ShipConfig _shipConfig;

        public IAsteroidConfig AsteroidConfig => _asteroidConfig;

        public IFlyingSaucerConfig FlyingSaucerConfig => _flyingSaucerConfig;

        public IInputConfig InputConfig => _inputConfig;

        public IShipConfig ShipConfig => _shipConfig;
    }
}
