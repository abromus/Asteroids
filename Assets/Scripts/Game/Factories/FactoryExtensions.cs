using Asteroids.Core.Factories;
using Asteroids.Game.Factory;

namespace Asteroids.Game
{
    public static class FactoryExtensions
    {
        public static IAsteroidViewFactory GetAsteroidViewFactory(this IFactoryStorage factoryStorage)
        {
            return factoryStorage.GetFactory<IAsteroidViewFactory>();
        }

        public static IFlyingSaucerViewFactory GetFlyingSaucerViewFactory(this IFactoryStorage factoryStorage)
        {
            return factoryStorage.GetFactory<IFlyingSaucerViewFactory>();
        }

        public static IShipViewFactory GetShipViewFactory(this IFactoryStorage factoryStorage)
        {
            return factoryStorage.GetFactory<IShipViewFactory>();
        }
    }
}
