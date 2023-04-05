using System.Linq;
using Asteroids.Game.Factory;
using Asteroids.Core.Screens;
using Asteroids.Core.Settings;
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

            var shipViewFactory = _options.UiFactories
                .FirstOrDefault(factory => factory.UiFactoryType == UiFactoryType.ShipViewFactory) as IShipViewFactory;

            var shipFactory = new ShipFactory(shipViewFactory);
            shipFactory.Create();
        }
    }
}
