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

        public void CloseScreen(IScreen screen)
        {
            screen.Close();
        }

        public void CloseAllScreens()
        {
            for (int i = _activeScreens.Count - 1; i >= 0; i--)
            {
                var screen = _activeScreens[i];
                screen.Close();

                OnClosed(screen);
            }
        }

        public void ShowGame(IShipPresenter shipPresenter)
        {
            var options = new GameScreenOptions(shipPresenter);
            CreateScreen(ScreenType.Game, options);
        }

        public IGameOverScreen ShowGameOver(int score)
        {
            var options = new GameOverScreenOptions(score);
            var screen = CreateScreen(ScreenType.GameOver, options);

            return screen as IGameOverScreen;
        }

        private IScreen CreateScreen(ScreenType type, Options options)
        {
            var screenPrefab = _gameData.ConfigStorage.GetScreenConfig().Screens
                .FirstOrDefault(screen => screen.ScreenType == type);

            if (screenPrefab == null)
                return null;

            var screen = Instantiate(screenPrefab, _transform);

            screen.Init(options);
            screen.Closed += OnClosed;

            _activeScreens.Add(screen);
            _updater.Add(screen);

            return screen;
        }

        private void OnClosed(IScreen screen)
        {
            if (this == null)
                return;

            screen.Closed -= OnClosed;

            _activeScreens.Remove(screen);
            _updater.Remove(screen);

            if (screen != null)
                Destroy((screen as MonoBehaviour).gameObject);
        }
    }
}
