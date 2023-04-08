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
        private readonly IUpdater _updater;

        private ShipPresenter _shipPresenter;

        public IGameData GameData => _gameData;

        public Game(IGameData gameData, IUpdater updater)
        {
            _gameData = gameData;
            _updater = updater;
        }

        public void Destroy()
        {
            _shipPresenter.Destroy();
        }

        public void Run()
        {
            /*_stateMachine = new StateMachine();
            _stateMachine.Add(new ShipState());
            _stateMachine.Add(new EnemiesState());
            _stateMachine.Add(new UiState());
            _stateMachine.Add(new NewGameState());*/

            var uiFactories = _gameData.ConfigStorage.GetUiFactoryConfig().UiFactories;
            var shipViewFactory = uiFactories.FirstOrDefault(factory => factory.UiFactoryType == UiFactoryType.ShipViewFactory) as IShipViewFactory;
            _gameData.FactoryStorage.AddFactory(shipViewFactory);

            CreateShip();
            //CreateEnemies();
            //ShowUi();
        }

        private void CreateShip()
        {
            var shipViewFactory = _gameData.FactoryStorage.GetShipViewFactory();
            var inputSystem = _gameData.ServiceStorage.GetInputSystem();
            var inputConfig = _gameData.ConfigStorage.GetInputConfig();
            var shipConfig = _gameData.ConfigStorage.GetShipConfig();

            var shipFactory = new ShipFactory(_updater, shipViewFactory, inputSystem, inputConfig, shipConfig);
            
            _shipPresenter = shipFactory.Create();
            _shipPresenter.Enable();
        }
    }
}
