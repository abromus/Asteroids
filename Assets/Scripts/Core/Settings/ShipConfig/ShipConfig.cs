using UnityEngine;

namespace Asteroids.Core.Settings
{
    [CreateAssetMenu(fileName = "ShipConfig", menuName = "Settings/ShipConfig")]
    public sealed class ShipConfig : ScriptableObject, IShipConfig
    {
        [SerializeField] private float _damping;
        [SerializeField] private float _speed;

        public float Damping => _damping;

        public float Speed => _speed;
    }
}
