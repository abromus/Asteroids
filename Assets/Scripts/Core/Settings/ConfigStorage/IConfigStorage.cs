namespace Asteroids.Core.Settings
{
    public interface IConfigStorage : IConfig
    {
        public void AddConfig<TConfig>(TConfig config) where TConfig : class, IConfig;

        public void Destroy();

        public TConfig GetConfig<TConfig>() where TConfig : class, IConfig;
    }
}
