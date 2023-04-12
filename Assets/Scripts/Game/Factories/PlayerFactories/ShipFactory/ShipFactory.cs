﻿using Asteroids.Core.Services;
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
        private readonly IMachineGunFactory _machineGunFactory;

        public ShipFactory(IUpdater updater, IShipViewFactory viewFactory, IShipConfig config, IInputSystem inputSystem, IInputConfig inputConfig, IMachineGunFactory machineGunFactory)
        {
            _updater = updater;
            _viewFactory = viewFactory;
            _config = config;
            _inputSystem = inputSystem;
            _inputConfig = inputConfig;
            _machineGunFactory = machineGunFactory;
        }

        public IShipPresenter Create()
        {
            var model = new ShipModel();
            var machineGunPresenter = CreateMachineGun();
            var view = _viewFactory.Create(_inputConfig, machineGunPresenter.View);
            var presenter = new ShipPresenter(_updater, model, view, _config, _inputSystem, machineGunPresenter);

            return presenter;
        }

        private IMachineGunPresenter CreateMachineGun()
        {
            var machineGunPresenter = _machineGunFactory.Create();
            machineGunPresenter.Enable();

            return machineGunPresenter;
        }
    }
}