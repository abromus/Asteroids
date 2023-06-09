﻿using Asteroids.Core.Settings;

namespace Asteroids.Game.Settings
{
    public static class ConfigExtensions
    {
        public static IAsteroidConfig GetAsteroidConfig(this IConfigStorage configStorage)
        {
            return configStorage.GetConfig<IAsteroidConfig>();
        }

        public static IAsteroidSpawnerConfig GetAsteroidSpawnerConfig(this IConfigStorage configStorage)
        {
            return configStorage.GetConfig<IAsteroidSpawnerConfig>();
        }

        public static IBulletConfig GetBulletConfig(this IConfigStorage configStorage)
        {
            return configStorage.GetConfig<IBulletConfig>();
        }

        public static IFlyingSaucerConfig GetFlyingSaucerConfig(this IConfigStorage configStorage)
        {
            return configStorage.GetConfig<IFlyingSaucerConfig>();
        }

        public static IFlyingSaucerSpawnerConfig GetFlyingSaucerSpawnerConfig(this IConfigStorage configStorage)
        {
            return configStorage.GetConfig<IFlyingSaucerSpawnerConfig>();
        }

        public static IInputConfig GetInputConfig(this IConfigStorage configStorage)
        {
            return configStorage.GetConfig<IInputConfig>();
        }

        public static ILaserConfig GetLaserConfig(this IConfigStorage configStorage)
        {
            return configStorage.GetConfig<ILaserConfig>();
        }

        public static ILaserGunConfig GetLaserGunConfig(this IConfigStorage configStorage)
        {
            return configStorage.GetConfig<ILaserGunConfig>();
        }

        public static IMachineGunConfig GetMachineGunConfig(this IConfigStorage configStorage)
        {
            return configStorage.GetConfig<IMachineGunConfig>();
        }

        public static IShipConfig GetShipConfig(this IConfigStorage configStorage)
        {
            return configStorage.GetConfig<IShipConfig>();
        }
    }
}
