using System.Linq;
using Asteroids.Core;
using Asteroids.Core.Screens;
using Asteroids.Core.Settings;
using UnityEngine;

namespace Asteroids.Game.Services
{
    public sealed class ScreenSystem : UiService, IScreenSystem
    {
        private IGameData _gameData;
        private Transform _transform;

        public override UiServiceType UiServiceType => UiServiceType.ScreenSystem;

        public void Init(IGameData gameData, Transform transform)
        {
            _gameData = gameData;
            _transform = transform;
        }

        public void ShowGame()
        {
            var screenPrefab = _gameData.ConfigStorage.GetScreenConfig().Screens
                .FirstOrDefault(screen => screen.ScreenType == ScreenType.Game);

            if (screenPrefab == null)
                return;

            var screen = Instantiate(screenPrefab, _transform);

            var options = new Options(_gameData.ConfigStorage.GetUiFactoryConfig().UiFactories);

            screen.Init(options);
        }
    }
}
