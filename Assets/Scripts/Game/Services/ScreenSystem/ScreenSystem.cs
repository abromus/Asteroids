using System.Collections.Generic;
using System.Linq;
using Asteroids.Core;
using Asteroids.Core.Screens;
using Asteroids.Core.Settings;
using Asteroids.Game.Screens;
using UnityEngine;
using Bounds = Asteroids.Core.Bounds;

namespace Asteroids.Game.Services
{
    public sealed class ScreenSystem : UiService, IScreenSystem
    {
        private IGameData _gameData;
        private IUpdater _updater;
        private Bounds _bounds;
        private Transform _transform;

        private List<IScreen> _activeScreens;

        public override UiServiceType UiServiceType => UiServiceType.ScreenSystem;

        public Bounds Bounds => _bounds;

        public void Init(IGameData gameData, IUpdater updater, Bounds bounds, Transform transform)
        {
            _gameData = gameData;
            _updater = updater;
            _bounds = bounds;
            _transform = transform;

            _activeScreens = new List<IScreen>();
        }

        public void ShowGame(IShipPresenter shipPresenter)
        {
            var screenPrefab = _gameData.ConfigStorage.GetScreenConfig().Screens
                .FirstOrDefault(screen => screen.ScreenType == ScreenType.Game);

            if (screenPrefab == null)
                return;

            var screen = Instantiate(screenPrefab, _transform);

            var options = new GameScreenOptions(_gameData.ConfigStorage.GetUiFactoryConfig().UiFactories, shipPresenter);

            screen.Init(options);
            screen.Closed += OnClosed;

            _activeScreens.Add(screen);
            _updater.Add(screen);
        }

        private void OnClosed(IScreen screen)
        {
            screen.Closed -= OnClosed;

            _activeScreens.Remove(screen);
            _updater.Remove(screen);

            Destroy((screen as MonoBehaviour).gameObject);
        }
    }
}
