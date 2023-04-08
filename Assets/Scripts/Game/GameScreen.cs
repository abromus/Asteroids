using Asteroids.Core.Screens;
using Screen = Asteroids.Core.Screens.Screen;

namespace Asteroids.Game
{
    public sealed class GameScreen : Screen
    {
        private Options _options;

        public override ScreenType ScreenType => ScreenType.Game;

        public override void Init(Options options)
        {
            _options = options;
        }
    }
}
