using UnityEngine;

namespace Asteroids.Game.Settings
{
    [CreateAssetMenu(fileName = nameof(ShipConfig), menuName = ConfigKeys.PlayerPathKey + nameof(ShipConfig))]
    public sealed class ShipConfig : ScriptableObject, IShipConfig
    {
        [SerializeField] private float _damping;
        [SerializeField] private float _speed;

        public float Damping => _damping;

        public float Speed => _speed;
    }
}
