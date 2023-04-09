﻿namespace Asteroids.Core.Settings
{
    public static class ConfigExtensions
    {
        public static IAsteroidConfig GetAsteroidConfig(this IConfigStorage configStorage)
        {
            return configStorage.GetConfig<IAsteroidConfig>();
        }

        public static ICanvasConfig GetCanvasConfig(this IConfigStorage configStorage)
        {
            return configStorage.GetConfig<ICanvasConfig>();
        }

        public static IFlyingSaucerConfig GetFlyingSaucerConfig(this IConfigStorage configStorage)
        {
            return configStorage.GetConfig<IFlyingSaucerConfig>();
        }

        public static IInputConfig GetInputConfig(this IConfigStorage configStorage)
        {
            return configStorage.GetConfig<IInputConfig>();
        }

        public static IScreenConfig GetScreenConfig(this IConfigStorage configStorage)
        {
            return configStorage.GetConfig<IScreenConfig>();
        }

        public static IShipConfig GetShipConfig(this IConfigStorage configStorage)
        {
            return configStorage.GetConfig<IShipConfig>();
        }

        public static IUiFactoryConfig GetUiFactoryConfig(this IConfigStorage configStorage)
        {
            return configStorage.GetConfig<IUiFactoryConfig>();
        }

        public static IUiServiceConfig GetUiServiceConfig(this IConfigStorage configStorage)
        {
            return configStorage.GetConfig<IUiServiceConfig>();
        }
    }
}
