using Asteroids.Core;
using Asteroids.Core.Settings;

namespace Asteroids.Game.Initializers
{
    public sealed class FactoryInitializer : IFactoryInitializer
    {
        private readonly IGame _game;

        public FactoryInitializer(IGame game)
        {
            _game = game;
        }

        public void Initialize()
        {
            InitFactories();
        }

        private void InitFactories()
        {
            var uiFactories = _game.GameData.ConfigStorage.GetUiFactoryConfig().UiFactories;

            _game.GameData.FactoryStorage.AddFactory(uiFactories.GetAsteroidViewFactory());
            _game.GameData.FactoryStorage.AddFactory(uiFactories.GetFlyingSaucerViewFactory());
            _game.GameData.FactoryStorage.AddFactory(uiFactories.GetShipViewFactory());

        }
    }
}
