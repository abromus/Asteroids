using Asteroids.Core;
using Asteroids.Core.Services;
using Asteroids.Game.Services;
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
        private readonly IScreenSystem _screenSystem;
        private readonly ILaserGunFactory _laserGunFactory;
        private readonly IMachineGunFactory _machineGunFactory;

        public ShipFactory(
            IUpdater updater,
            IShipViewFactory viewFactory,
            IShipConfig config,
            IInputSystem inputSystem,
            IInputConfig inputConfig,
            IScreenSystem screenSystem,
            ILaserGunFactory laserGunFactory,
            IMachineGunFactory machineGunFactory)
        {
            _updater = updater;
            _viewFactory = viewFactory;
            _config = config;
            _inputSystem = inputSystem;
            _inputConfig = inputConfig;
            _screenSystem = screenSystem;
            _laserGunFactory = laserGunFactory;
            _machineGunFactory = machineGunFactory;
        }

        public IShipPresenter Create()
        {
            var model = new ShipModel();
            var machineGunPresenter = CreateMachineGun();
            var laserGunPresenter = CreateLaserGun();
            var view = _viewFactory.Create(_inputConfig, machineGunPresenter.View, laserGunPresenter.View);
            var presenter = new ShipPresenter(
                _updater,
                model,
                view,
                _config,
                _inputSystem,
                _screenSystem,
                machineGunPresenter,
                laserGunPresenter);

            return presenter;
        }

        private IMachineGunPresenter CreateMachineGun()
        {
            var machineGunPresenter = _machineGunFactory.Create();
            machineGunPresenter.Enable();
            machineGunPresenter.SetPosition(Float3.Zero);

            return machineGunPresenter;
        }

        private ILaserGunPresenter CreateLaserGun()
        {
            var laserGunPresenter = _laserGunFactory.Create();
            laserGunPresenter.Enable();
            laserGunPresenter.SetPosition(Float3.Zero);

            return laserGunPresenter;
        }
    }
}
