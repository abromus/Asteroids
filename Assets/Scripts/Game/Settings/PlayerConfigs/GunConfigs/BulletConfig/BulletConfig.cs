using UnityEngine;

namespace Asteroids.Game.Settings
{
    [CreateAssetMenu(fileName = nameof(BulletConfig), menuName = ConfigKeys.PlayerGunPathKey + nameof(BulletConfig))]
    public sealed class BulletConfig : ScriptableObject, IBulletConfig
    {
        [SerializeField] private float _speed;
        [SerializeField] private float _maxDistance;

        public float MaxDistance => _maxDistance;

        public float Speed => _speed;
    }
}
