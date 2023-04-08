using Asteroids.Core.Settings;
using System.Collections.Generic;
using System.Linq;

namespace Asteroids.Core.Factories
{
    public static class FactoryExtensions
    {
        public static IGameSceneControllerFactory GetGameSceneControllerFactory(this IFactoryStorage factoryStorage)
        {
            return factoryStorage.GetFactory<IGameSceneControllerFactory>();
        }

        public static IGameSceneControllerFactory GetGameSceneControllerFactory(this IReadOnlyList<IUiFactory> uiFactories)
        {
            return uiFactories.FirstOrDefault(factory => factory.UiFactoryType == UiFactoryType.GameSceneControllerFactory) as IGameSceneControllerFactory;
        }
    }
}
