using Asteroids.Core.Settings;
using UnityEngine;

namespace Asteroids.Game.Factory
{
    public sealed class ShipViewFactory : UiFactory, IShipViewFactory
    {
        [SerializeField] private ShipView _shipPrefab;

        public override UiFactoryType UiFactoryType => UiFactoryType.ShipViewFactory;

        public ShipView Create()
        {
            return Instantiate(_shipPrefab);
        }
    }
}
