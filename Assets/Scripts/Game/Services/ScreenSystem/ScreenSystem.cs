using System.Collections.Generic;
using System.Linq;
using Asteroids.Core;
using Asteroids.Core.Screens;
using Asteroids.Core.Services;
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

        private bool _isDestroyed;

        public override UiServiceType UiServiceType => UiServiceType.ScreenSystem;

        public Bounds Bounds => _bounds;

        public bool IsDestroyed => _isDestroyed;

        public void Init(IGameData gameData, IUpdater updater, Bounds bounds, Transform transform)
        {
            _gameData = gameData;
            _updater = updater;
            _bounds = bounds;
            _transform = transform;

            _activeScreens = new List<IScreen>();
        }

        public void Destroy()
        {
            CloseAllScreens();

            _activeScreens.Clear();
            _activeScreens = null;

            _isDestroyed = true;
        }

        public void CloseScreen(IScreen screen)
        {
            screen.Close();
        }

        public void CloseAllScreens()
        {
            if (_activeScreens == null)
            {
                return;
            }

            for (int i = _activeScreens.Count - 1; i >= 0; i--)
            {
                var screen = _activeScreens[i];

                if (screen == null)
                    return;

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
            if (this == null || screen == null)
                return;

            screen.Closed -= OnClosed;

            _activeScreens.Remove(screen);

            _updater?.Remove(screen);

            var mono = screen as MonoBehaviour;

            if (mono != null && mono.gameObject != null)
                DestroyImmediate(mono.gameObject);
        }
    }
}
