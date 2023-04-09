using UnityEngine;

namespace Asteroids.Game.Settings
{
    [CreateAssetMenu(fileName = "MachineGunConfig", menuName = "Settings/Game/Player/Gun/MachineGunConfig")]
    public sealed class MachineGunConfig : ScriptableObject, IMachineGunConfig
    {
        [SerializeField] private float _firingRate;

        public float FiringRate => _firingRate;
    }
}
