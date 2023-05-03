using Asteroids.Core.Screens;

namespace Asteroids.Game.Screens
{
    public sealed class GameScreenOptions : Options
    {
        private readonly IShipPresenter _shipPresenter;

        public IShipPresenter ShipPresenter => _shipPresenter;

        public GameScreenOptions(IShipPresenter shipPresenter)
        {
            _shipPresenter = shipPresenter;
        }
    }
}
