using Asteroids.Core.Settings;

namespace Asteroids.Game.Settings
{
    public static class ConfigExtensions
    {
        public static IAsteroidConfig GetAsteroidConfig(this IConfigStorage configStorage)
        {
            return configStorage.GetConfig<IAsteroidConfig>();
        }

        public static IFlyingSaucerConfig GetFlyingSaucerConfig(this IConfigStorage configStorage)
        {
            return configStorage.GetConfig<IFlyingSaucerConfig>();
        }

        public static IInputConfig GetInputConfig(this IConfigStorage configStorage)
        {
            return configStorage.GetConfig<IInputConfig>();
        }

        public static IShipConfig GetShipConfig(this IConfigStorage configStorage)
        {
            return configStorage.GetConfig<IShipConfig>();
        }
    }
}
