using Asteroids.Core.Settings;
using Asteroids.Game.Settings;
using UnityEngine;

namespace Asteroids.Game.Factory
{
    public sealed class ShipViewFactory : UiFactory, IShipViewFactory
    {
        [SerializeField] private ShipView _prefab;

        public override UiFactoryType UiFactoryType => UiFactoryType.ShipViewFactory;

        public IShipView Create(IInputConfig inputConfig, IMachineGunView machineGunView, ILaserGunView laserGunView)
        {
            var ship = Instantiate(_prefab);
            ship.Init(inputConfig, machineGunView, laserGunView);

            return ship;
        }
    }
}
