using Asteroids.Core.Services;
using Asteroids.Game.Settings;

namespace Asteroids.Game.Factory
{
    public sealed class ShipFactory : IShipFactory
    {
        private readonly IUpdater _updater;
        private readonly IShipViewFactory _viewFactory;
        private readonly IShipConfig _config;
        private readonly IInputSystem _inputSystem;
        private readonly IInputConfig _inputConfig;
        private readonly IBulletFactory _bulletFactory;

        public ShipFactory(IUpdater updater, IShipViewFactory viewFactory, IShipConfig config, IInputSystem inputSystem, IInputConfig inputConfig, IBulletFactory bulletFactory)
        {
            _updater = updater;
            _viewFactory = viewFactory;
            _config = config;
            _inputSystem = inputSystem;
            _inputConfig = inputConfig;
            _bulletFactory = bulletFactory;
        }

        public IShipPresenter Create()
        {
            var model = new ShipModel();
            var view = _viewFactory.Create(_inputConfig);
            var presenter = new ShipPresenter(_updater, model, view, _config, _inputSystem, _bulletFactory);

            return presenter;
        }
    }
}
