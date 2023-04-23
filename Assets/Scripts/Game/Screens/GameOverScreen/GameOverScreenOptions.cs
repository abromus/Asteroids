using System.Collections.Generic;
using Asteroids.Core.Screens;
using Asteroids.Core.Settings;

namespace Asteroids.Game.Screens
{
    public sealed class GameOverScreenOptions : Options
    {
        private readonly int _score;

        public int Score => _score;

        public GameOverScreenOptions(IReadOnlyList<IUiFactory> uiFactories, int score) : base(uiFactories)
        {
            _score = score;
        }
    }
}
