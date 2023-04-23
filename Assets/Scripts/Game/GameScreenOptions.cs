using System.Collections.Generic;
using Asteroids.Core.Screens;
using Asteroids.Core.Settings;

namespace Asteroids.Game.Screens
{
    public sealed class GameScreenOptions : Options
    {
        private readonly IShipPresenter _shipPresenter;

        public IShipPresenter ShipPresenter => _shipPresenter;

        public GameScreenOptions(IReadOnlyList<IUiFactory> uiFactories, IShipPresenter shipPresenter) : base(uiFactories)
        {
            _shipPresenter = shipPresenter;
        }
    }
}
