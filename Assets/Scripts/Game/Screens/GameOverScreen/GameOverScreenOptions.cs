using Asteroids.Core.Screens;

namespace Asteroids.Game.Screens
{
    public sealed class GameOverScreenOptions : Options
    {
        private readonly int _score;

        public int Score => _score;

        public GameOverScreenOptions(int score)
        {
            _score = score;
        }
    }
}
