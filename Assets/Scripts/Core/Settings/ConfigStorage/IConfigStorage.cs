﻿namespace Asteroids.Core.Settings
{
    public interface IConfigStorage : IConfig
    {
        public TConfig GetConfig<TConfig>() where TConfig : class, IConfig;
    }
}