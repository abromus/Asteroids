using UnityEngine;

namespace Asteroids.Game.Settings
{
    [CreateAssetMenu(fileName = nameof(ShipConfig), menuName = ConfigKeys.PlayerPathKey + nameof(ShipConfig))]
    public sealed class ShipConfig : ScriptableObject, IShipConfig
    {
        [SerializeField] private float _angularVelocity;
        [SerializeField] private float _speed;

        public float AngularVelocity => _angularVelocity;

        public float Speed => _speed;
    }
}
