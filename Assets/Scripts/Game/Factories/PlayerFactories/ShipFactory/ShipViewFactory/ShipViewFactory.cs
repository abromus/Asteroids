using Asteroids.Core.Settings;
using Asteroids.Game.Settings;
using UnityEngine;

namespace Asteroids.Game.Factory
{
    public sealed class ShipViewFactory : UiFactory, IShipViewFactory
    {
        [SerializeField] private ShipView _prefab;

        public override UiFactoryType UiFactoryType => UiFactoryType.ShipViewFactory;

        public IShipView Create(IInputConfig inputConfig, IMachineGunView machineGunView)
        {
            var ship = Instantiate(_prefab);
            ship.Init(inputConfig, machineGunView);

            return ship;
        }
    }
}
