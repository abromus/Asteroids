﻿using Asteroids.Game.Settings;

namespace Asteroids.Game
{
    public interface IShipView : IView
    {
        public void Init(IInputConfig inputConfig);
    }
}