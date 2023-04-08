using System.Linq;
using Asteroids.Core;
using Asteroids.Core.Services;
using Asteroids.Core.Settings;
using Asteroids.Game.Factory;

namespace Asteroids.Game
{
    public sealed class Game : IGame
    {
        private readonly IGameData _gameData;
        private StateMachine _stateMachine;

        public IGameData GameData => _gameData;

        public Game(IGameData gameData)
        {
            _gameData = gameData;
        }

        public void Run()
        {
            _stateMachine = new StateMachine();

            var uiFactories = _gameData.ConfigStorage.GetUiFactoryConfig().UiFactories;
            var shipViewFactory = uiFactories.FirstOrDefault(factory => factory.UiFactoryType == UiFactoryType.ShipViewFactory) as IShipViewFactory;
            _gameData.FactoryStorage.AddFactory(shipViewFactory);

            var shipFactory = new ShipFactory(shipViewFactory);
            shipFactory.Create();
        }
    }
}
