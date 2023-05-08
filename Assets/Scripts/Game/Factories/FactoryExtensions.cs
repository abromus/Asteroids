using System.Collections.Generic;
using System.Linq;
using Asteroids.Core.Factories;
using Asteroids.Core.Settings;
using Asteroids.Game.Factory;

namespace Asteroids.Game
{
    public static class FactoryExtensions
    {
        public static IAsteroidFactory GetAsteroidFactory(this IFactoryStorage factoryStorage)
        {
            return factoryStorage.GetFactory<IAsteroidFactory>();
        }

        public static IAsteroidViewFactory GetAsteroidViewFactory(this IReadOnlyList<IUiFactory> uiFactories)
        {
            return uiFactories.GetFactory<IAsteroidViewFactory>(UiFactoryType.AsteroidViewFactory);
        }

        public static IBulletFactory GetBulletFactory(this IFactoryStorage factoryStorage)
        {
            return factoryStorage.GetFactory<IBulletFactory>();
        }

        public static IBulletViewFactory GetBulletViewFactory(this IReadOnlyList<IUiFactory> uiFactories)
        {
            return uiFactories.GetFactory<IBulletViewFactory>(UiFactoryType.BulletViewFactory);
        }

        public static IFlyingSaucerFactory GetFlyingSaucerFactory(this IFactoryStorage factoryStorage)
        {
            return factoryStorage.GetFactory<IFlyingSaucerFactory>();
        }

        public static IFlyingSaucerViewFactory GetFlyingSaucerViewFactory(this IReadOnlyList<IUiFactory> uiFactories)
        {
            return uiFactories.GetFactory<IFlyingSaucerViewFactory>(UiFactoryType.FlyingSaucerViewFactory);
        }

        public static ILaserFactory GetLaserFactory(this IFactoryStorage factoryStorage)
        {
            return factoryStorage.GetFactory<ILaserFactory>();
        }

        public static ILaserViewFactory GetLaserViewFactory(this IReadOnlyList<IUiFactory> uiFactories)
        {
            return uiFactories.GetFactory<ILaserViewFactory>(UiFactoryType.LaserViewFactory);
        }

        public static ILaserGunFactory GetLaserGunFactory(this IFactoryStorage factoryStorage)
        {
            return factoryStorage.GetFactory<ILaserGunFactory>();
        }

        public static ILaserGunViewFactory GetLaserGunViewFactory(this IReadOnlyList<IUiFactory> uiFactories)
        {
            return uiFactories.GetFactory<ILaserGunViewFactory>(UiFactoryType.LaserGunViewFactory);
        }

        public static IMachineGunFactory GetMachineGunFactory(this IFactoryStorage factoryStorage)
        {
            return factoryStorage.GetFactory<IMachineGunFactory>();
        }

        public static IMachineGunViewFactory GetMachineGunViewFactory(this IReadOnlyList<IUiFactory> uiFactories)
        {
            return uiFactories.GetFactory<IMachineGunViewFactory>(UiFactoryType.MachineGunViewFactory);
        }

        public static IShipFactory GetShipFactory(this IFactoryStorage factoryStorage)
        {
            return factoryStorage.GetFactory<IShipFactory>();
        }

        public static IShipViewFactory GetShipViewFactory(this IReadOnlyList<IUiFactory> uiFactories)
        {
            return uiFactories.GetFactory<IShipViewFactory>(UiFactoryType.ShipViewFactory);
        }

        private static TFactory GetFactory<TFactory>(this IReadOnlyList<IUiFactory> uiFactories, UiFactoryType factoryType)
            where TFactory : class, IFactory
        {
            return uiFactories.FirstOrDefault(factory => factory.UiFactoryType == factoryType) as TFactory;
        }
    }
}
