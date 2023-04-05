using Asteroids.Core.Factory;

namespace Asteroids.Game.Factory
{
    public interface IShipFactory : IFactory
    {
        public ShipPresenter Create();
    }
}
