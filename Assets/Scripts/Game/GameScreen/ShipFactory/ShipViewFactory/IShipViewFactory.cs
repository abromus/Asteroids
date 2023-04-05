using Asteroids.Core.Factory;

namespace Asteroids.Game.Factory
{
    public interface IShipViewFactory : IFactory
    {
        public ShipView Create();
    }
}
