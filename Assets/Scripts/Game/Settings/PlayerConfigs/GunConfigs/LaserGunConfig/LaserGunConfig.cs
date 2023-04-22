using UnityEngine;

namespace Asteroids.Game.Settings
{
    [CreateAssetMenu(fileName = "LaserGunConfig", menuName = "Settings/Game/Player/Gun/LaserGunConfig")]
    public sealed class LaserGunConfig : ScriptableObject, ILaserGunConfig
    {
        [SerializeField] private float _firingRate;
        [SerializeField] private Vector3 _offset;

        public float FiringRate => _firingRate;

        public Vector3 Offset => _offset;
    }
}
