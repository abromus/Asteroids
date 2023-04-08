using Asteroids.Core.Factories;

namespace Asteroids.Core.Services
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
