using UnityEngine;

namespace Asteroids.Game.Settings
{
    [CreateAssetMenu(fileName = nameof(LaserGunConfig), menuName = ConfigKeys.PlayerGunPathKey + nameof(LaserGunConfig))]
    public sealed class LaserGunConfig : ScriptableObject, ILaserGunConfig
    {
        [SerializeField] private int _capacity;
        [SerializeField] private float _firingRate;
        [SerializeField] private float _regenerateTime;
        [SerializeField] private float _reloadTime;
        [SerializeField] private Vector3 _offset;

        public int Capacity => _capacity;

        public float FiringRate => _firingRate;

        public float RegenerateTime => _regenerateTime;

        public float ReloadTime => _reloadTime;

        public Vector3 Offset => _offset;
    }
}
