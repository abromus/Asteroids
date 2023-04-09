using System;
using System.Collections.Generic;
using UnityEngine;

namespace Asteroids.Core.Settings
{
    [CreateAssetMenu(fileName = "ConfigStorage", menuName = "Settings/ConfigStorage")]
    public sealed class ConfigStorage : ScriptableObject, IConfigStorage
    {
        [SerializeField] private CanvasConfig _canvasConfig;
        [SerializeField] private ScreenConfig _screenConfig;
        [SerializeField] private UiFactoryConfig _uiFactoryConfig;
        [SerializeField] private UiServiceConfig _uiServiceConfig;

        private Dictionary<Type, IConfig> _configs;

        public void Init()
        {
            _configs = new Dictionary<Type, IConfig>()
            {
                [typeof(ICanvasConfig)] = _canvasConfig,
                [typeof(IScreenConfig)] = _screenConfig,
                [typeof(IUiFactoryConfig)] = _uiFactoryConfig,
                [typeof(IUiServiceConfig)] = _uiServiceConfig,
            };
        }
        public void AddConfig<TConfig>(TConfig config) where TConfig : class, IConfig
        {
            var type = typeof(TConfig);

            if (_configs.ContainsKey(type))
                _configs[type] = config;
            else
                _configs.Add(type, config);
        }

        public TConfig GetConfig<TConfig>() where TConfig : class, IConfig
        {
            return _configs[typeof(TConfig)] as TConfig;
        }
    }
}
