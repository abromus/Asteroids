using Asteroids.Core.Factories;
using Asteroids.Game.Factory;

namespace Asteroids.Game
{
    public static class FactoryExtensions
    {
        public static IShipViewFactory GetShipViewFactory(this IFactoryStorage factoryStorage)
        {
            return factoryStorage.GetFactory<IShipViewFactory>();
        }
    }
}
