using System;
using Asteroids.Core;
using Asteroids.Core.Screens;
using UnityEngine;
using UnityEngine.UI;
using Screen = Asteroids.Core.Screens.Screen;

namespace Asteroids.Game.Screens
{
    public sealed class GameOverScreen : Screen, IGameOverScreen
    {
        [SerializeField] private Text _score;
        [SerializeField] private Button _restartButton;

        private GameOverScreenOptions _options;

        public override ScreenType ScreenType => ScreenType.GameOver;

        public Action Restarted { get; set; }

        public override void Init(Options options)
        {
            _options = options as GameOverScreenOptions;

            _restartButton.onClick.AddListener(Restart);

            UpdateView();
        }

        public override void Close()
        {
            _restartButton.onClick.RemoveAllListeners();

            Closed.SafeInvoke(this);
        }

        public override void Tick(float deltaTime) { }

        private void Restart()
        {
            Restarted.SafeInvoke();
        }

        private void UpdateView()
        {
            _score.text = string.Format(GameOverScreenKeys.ScoreKey, _options.Score);
        }

        private sealed class GameOverScreenKeys
        {
            public const string ScoreKey = "¬аш счЄт: {0}!";
        }
    }
}
