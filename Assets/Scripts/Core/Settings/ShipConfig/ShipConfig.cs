using UnityEngine;

namespace Asteroids.Core.Settings
{
    [CreateAssetMenu(fileName = "ShipConfig", menuName = "Settings/ShipConfig")]
    public sealed class ShipConfig : ScriptableObject, IShipConfig
    {
        [SerializeField] private string _name;

        public string Name => _name;
    }
}
