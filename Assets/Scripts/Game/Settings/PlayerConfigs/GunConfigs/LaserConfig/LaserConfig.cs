using UnityEngine;

namespace Asteroids.Game.Settings
{
    [CreateAssetMenu(fileName = nameof(LaserConfig), menuName = ConfigKeys.PlayerGunPathKey + nameof(LaserConfig))]
    public sealed class LaserConfig : ScriptableObject, ILaserConfig
    {
        [SerializeField] private float _speed;
        [SerializeField] private float _maxDistance;

        public float MaxDistance => _maxDistance;

        public float Speed => _speed;
    }
}
