using Asteroids.Core.Services;
using Asteroids.Core.Settings;
using UnityEngine.PlayerLoop;

namespace Asteroids.Game.Factory
{
    public sealed class ShipFactory : IShipFactory
    {
        private readonly IUpdater _updater;
        private readonly IShipViewFactory _shipViewFactory;
        private readonly IInputSystem _inputSystem;
        private readonly IInputConfig _inputConfig;
        private readonly IShipConfig _shipConfig;

        public ShipFactory(IUpdater updater, IShipViewFactory shipViewFactory, IInputSystem inputSystem, IInputConfig inputConfig, IShipConfig shipConfig)
        {
            _updater = updater;
            _shipViewFactory = shipViewFactory;
            _inputSystem = inputSystem;
            _inputConfig = inputConfig;
            _shipConfig = shipConfig;
        }

        public ShipPresenter Create()
        {
            var shipModel = new ShipModel();
            var shipView = _shipViewFactory.Create(_inputConfig);
            var shipPresenter = new ShipPresenter(_updater, shipModel, shipView, _inputSystem, _shipConfig);

            return shipPresenter;
        }
    }
}
