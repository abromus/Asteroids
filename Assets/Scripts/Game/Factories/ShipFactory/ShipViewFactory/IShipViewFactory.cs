using Asteroids.Core.Factories;

namespace Asteroids.Game.Factory
{
    public interface IShipViewFactory : IFactory
    {
        public ShipView Create();
    }
}
