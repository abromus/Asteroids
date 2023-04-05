using System;
using System.Collections.Generic;
using UnityEngine;

namespace Asteroids.Core.Settings
{
    [CreateAssetMenu(fileName = "ConfigStorage", menuName = "Settings/ConfigStorage")]
    public sealed class ConfigStorage : ScriptableObject, IConfigStorage
    {
        [SerializeField] private CanvasConfig _canvasConfig;
        [SerializeField] private InputConfig _inputConfig;
        [SerializeField] private ScreenConfig _screenConfig;
        [SerializeField] private ShipConfig _shipConfig;
        [SerializeField] private UiFactoryConfig _uiFactoryConfig;
        [SerializeField] private UiServiceConfig _uiServiceConfig;

        private Dictionary<Type, IConfig> _configs;

        public void Init()
        {
            _configs = new Dictionary<Type, IConfig>()
            {
                [typeof(ICanvasConfig)] = _canvasConfig,
                [typeof(IInputConfig)] = _inputConfig,
                [typeof(IScreenConfig)] = _screenConfig,
                [typeof(IShipConfig)] = _shipConfig,
                [typeof(IUiFactoryConfig)] = _uiFactoryConfig,
                [typeof(IUiServiceConfig)] = _uiServiceConfig,
            };
        }

        public TConfig GetConfig<TConfig>() where TConfig : class, IConfig
        {
            return _configs[typeof(TConfig)] as TConfig;
        }
    }
}
