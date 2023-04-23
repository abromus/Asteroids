using Asteroids.Core;
using Asteroids.Core.Screens;
using UnityEngine;
using UnityEngine.UI;
using Screen = Asteroids.Core.Screens.Screen;

namespace Asteroids.Game.Screens
{
    public sealed class GameOverScreen : Screen
    {
        [SerializeField] private Text _score;

        private GameOverScreenOptions _options;

        public override ScreenType ScreenType => ScreenType.GameOver;

        public override void Init(Options options)
        {
            _options = options as GameOverScreenOptions;

            UpdateView();
        }

        public void Close()
        {
            Closed.SafeInvoke(this);
        }

        public override void Tick(float deltaTime) { }

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
