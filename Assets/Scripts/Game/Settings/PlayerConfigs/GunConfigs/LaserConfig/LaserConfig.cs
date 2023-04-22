using UnityEngine;

namespace Asteroids.Game.Settings
{
    [CreateAssetMenu(fileName = "LaserConfig", menuName = "Settings/Game/Player/Gun/LaserConfig")]
    public sealed class LaserConfig : ScriptableObject, ILaserConfig
    {
        [SerializeField] private float _speed;
        [SerializeField] private float _maxDistance;

        public float MaxDistance => _maxDistance;

        public float Speed => _speed;
    }
}
