using Asteroids.Core.Factories;
using Asteroids.Core.Settings;

namespace Asteroids.Game.Factory
{
    public interface IShipViewFactory : IFactory
    {
        public ShipView Create(IInputConfig inputConfig);
    }
}
