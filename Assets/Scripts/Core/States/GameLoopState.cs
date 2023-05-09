using Asteroids.Core.Factories;
using Asteroids.Core.Services;

namespace Asteroids.Core.States
{
    public sealed class GameLoopState : IEnterState
    {
        private readonly IGameData _gameData;

        private SceneController _gameSceneController;

        public GameLoopState(IGameData gameData)
        {
            _gameData = gameData;
        }

        public void Enter()
        {
            var gameSceneControllerFactory = _gameData.FactoryStorage.GetGameSceneControllerFactory();
            _gameSceneController = gameSceneControllerFactory.Create();

            _gameSceneController.Run(_gameData);
        }

        public void Exit() { }
    }
}
