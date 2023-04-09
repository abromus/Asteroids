using Asteroids.Core.Factories;

namespace Asteroids.Game.Factory
{
    public interface IShipFactory : IFactory
    {
        public IShipPresenter Create();
    }
}
