using System;
using System.Collections.Generic;
using UnityEngine;

namespace Asteroids.Settings
{
    [CreateAssetMenu(fileName = "ConfigStorage", menuName = "Settings/ConfigStorage")]
    public sealed class ConfigStorage : ScriptableObject, IConfigStorage
    {
        [SerializeField] private CanvasConfig _canvasConfig;
        [SerializeField] private ScreenConfig _screenConfig;
        [SerializeField] private UiServiceConfig _uiServiceConfig;

        private Dictionary<Type, IConfig> _configs;

        public void Init()
        {
            _configs = new Dictionary<Type, IConfig>()
            {
                [typeof(ICanvasConfig)] = _canvasConfig,
                [typeof(IScreenConfig)] = _screenConfig,
                [typeof(IUiServiceConfig)] = _uiServiceConfig,
            };
        }

        public TConfig GetConfig<TConfig>() where TConfig : class, IConfig
        {
            return _configs[typeof(TConfig)] as TConfig;
        }
    }
}
