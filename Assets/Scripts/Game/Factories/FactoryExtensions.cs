using System.Collections.Generic;
using System.Linq;
using Asteroids.Core.Factories;
using Asteroids.Core.Settings;
using Asteroids.Game.Factory;

namespace Asteroids.Game
{
    public static class FactoryExtensions
    {
        public static IAsteroidViewFactory GetAsteroidViewFactory(this IFactoryStorage factoryStorage)
        {
            return factoryStorage.GetFactory<IAsteroidViewFactory>();
        }

        public static IAsteroidViewFactory GetAsteroidViewFactory(this IReadOnlyList<IUiFactory> uiFactories)
        {
            return uiFactories.GetFactory<IAsteroidViewFactory>(UiFactoryType.AsteroidViewFactory);
        }

        public static IFlyingSaucerViewFactory GetFlyingSaucerViewFactory(this IFactoryStorage factoryStorage)
        {
            return factoryStorage.GetFactory<IFlyingSaucerViewFactory>();
        }

        public static IFlyingSaucerViewFactory GetFlyingSaucerViewFactory(this IReadOnlyList<IUiFactory> uiFactories)
        {
            return uiFactories.GetFactory<IFlyingSaucerViewFactory>(UiFactoryType.FlyingSaucerViewFactory);
        }

        public static IShipViewFactory GetShipViewFactory(this IFactoryStorage factoryStorage)
        {
            return factoryStorage.GetFactory<IShipViewFactory>();
        }

        public static IShipViewFactory GetShipViewFactory(this IReadOnlyList<IUiFactory> uiFactories)
        {
            return uiFactories.GetFactory<IShipViewFactory>(UiFactoryType.ShipViewFactory);
        }

        private static TFactory GetFactory<TFactory>(this IReadOnlyList<IUiFactory> uiFactories, UiFactoryType factoryType) where TFactory : class, IFactory
        {
            return uiFactories.FirstOrDefault(factory => factory.UiFactoryType == factoryType) as TFactory;
        }
    }
}
