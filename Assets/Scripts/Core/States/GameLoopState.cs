using Asteroids.Core.Factories;
using Asteroids.Core.Services;

namespace Asteroids.Core.States
{
    public sealed class GameLoopState : IEnterState
    {
        private readonly IGameData _gameData;

        public GameLoopState(IGameData gameData)
        {
            _gameData = gameData;
        }

        public void Enter()
        {
            var gameSceneControllerFactory = _gameData.FactoryStorage.GetGameSceneControllerFactory();
            var gameSceneController = gameSceneControllerFactory.Create();

            gameSceneController.Run(_gameData);
        }

        public void Exit() { }
    }
}
