using Asteroids.Core.Settings;
using UnityEngine;

namespace Asteroids.Game.Factory
{
    public sealed class ShipViewFactory : UiFactory, IShipViewFactory
    {
        [SerializeField] private ShipView _prefab;

        public override UiFactoryType UiFactoryType => UiFactoryType.ShipViewFactory;

        public ShipView Create(IInputConfig inputConfig)
        {
            var ship = Instantiate(_prefab);
            ship.Init(inputConfig);

            return ship;
        }
    }
}
