using System.Linq;
using Asteroids.Core;
using Asteroids.Core.Screens;
using Asteroids.Core.Settings;
using UnityEngine;
using Bounds = Asteroids.Core.Bounds;

namespace Asteroids.Game.Services
{
    public sealed class ScreenSystem : UiService, IScreenSystem
    {
        private IGameData _gameData;
        private Bounds _bounds;
        private Transform _transform;

        public override UiServiceType UiServiceType => UiServiceType.ScreenSystem;

        public Bounds Bounds => _bounds;

        public void Init(IGameData gameData, Bounds bounds, Transform transform)
        {
            _gameData = gameData;
            _bounds = bounds;
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
