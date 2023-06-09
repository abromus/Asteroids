﻿using Asteroids.Game.Settings;

namespace Asteroids.Game
{
    public interface IShipView : IView
    {
        public void DestroyView();

        public void Init(IInputConfig inputConfig, IMachineGunView machineGunView, ILaserGunView laserGunView);
    }
}
