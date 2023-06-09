﻿using Asteroids.Core;
using Asteroids.Game.Settings;

namespace Asteroids.Game.Initializers
{
    public sealed class ConfigInitializer : IConfigInitializer
    {
        private readonly IGame _game;
        private readonly IConfigData _configData;

        public ConfigInitializer(IGame game, IConfigData configData)
        {
            _game = game;
            _configData = configData;
        }

        public void Initialize()
        {
            InitConfigs();
        }

        private void InitConfigs()
        {
            _game.GameData.ConfigStorage.AddConfig(_configData.AsteroidConfig);
            _game.GameData.ConfigStorage.AddConfig(_configData.AsteroidSpawnerConfig);
            _game.GameData.ConfigStorage.AddConfig(_configData.BulletConfig);
            _game.GameData.ConfigStorage.AddConfig(_configData.FlyingSaucerConfig);
            _game.GameData.ConfigStorage.AddConfig(_configData.FlyingSaucerSpawnerConfig);
            _game.GameData.ConfigStorage.AddConfig(_configData.InputConfig);
            _game.GameData.ConfigStorage.AddConfig(_configData.LaserConfig);
            _game.GameData.ConfigStorage.AddConfig(_configData.LaserGunConfig);
            _game.GameData.ConfigStorage.AddConfig(_configData.MachineGunConfig);
            _game.GameData.ConfigStorage.AddConfig(_configData.ShipConfig);
        }
    }
}
