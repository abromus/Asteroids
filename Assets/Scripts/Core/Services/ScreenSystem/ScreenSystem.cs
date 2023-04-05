using System.Linq;
using Asteroids.Core.Screens;
using Asteroids.Core.Settings;
using UnityEngine;

namespace Asteroids.Core.Services
{
    public sealed class ScreenSystem : UiService, IScreenSystem
    {
        private IGame _game;
        private Transform _transform;

        public override UiServiceType UiServiceType => UiServiceType.ScreenSystem;

        public void Init(IGame game, Transform transform)
        {
            _game = game;
            _transform = transform;
        }

        public void ShowGame()
        {
            var screenPrefab = _game.ConfigStorage.GetConfig<IScreenConfig>().Screens
                .FirstOrDefault(screen => screen.ScreenType == ScreenType.Game);

            if (screenPrefab == null)
                return;

            var screen = Instantiate(screenPrefab, _transform);

            var options = new Options(_game.ConfigStorage.GetConfig<IUiFactoryConfig>().UiFactories);

            screen.Init(options);
        }
    }
}
