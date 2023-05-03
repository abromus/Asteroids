using UnityEngine;

namespace Asteroids.Game.Settings
{
    [CreateAssetMenu(fileName = nameof(MachineGunConfig), menuName = ConfigKeys.PlayerGunPathKey + nameof(MachineGunConfig))]
    public sealed class MachineGunConfig : ScriptableObject, IMachineGunConfig
    {
        [SerializeField] private float _firingRate;
        [SerializeField] private Vector3 _offset;

        public float FiringRate => _firingRate;

        public Vector3 Offset => _offset;
    }
}
