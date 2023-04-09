namespace Asteroids.Core.Settings
{
    public static class ConfigExtensions
    {
        public static ICanvasConfig GetCanvasConfig(this IConfigStorage configStorage)
        {
            return configStorage.GetConfig<ICanvasConfig>();
        }

        public static IScreenConfig GetScreenConfig(this IConfigStorage configStorage)
        {
            return configStorage.GetConfig<IScreenConfig>();
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
