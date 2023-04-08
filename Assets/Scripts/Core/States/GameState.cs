using Asteroids.Core.Services;

namespace Asteroids.Core.States
{
    public sealed class GameState : IEnterState
    {
        private readonly IStateMachine _stateMachine;

        public GameState(IStateMachine stateMachine)
        {
            _stateMachine = stateMachine;
        }

        public void Enter()
        {
            var gameSceneInfo = new SceneInfo(SceneKeys.GameSceneName, OnSceneLoad);

            _stateMachine.Enter<SceneLoaderState, SceneInfo>(gameSceneInfo);
        }

        public void Exit() { }

        private void OnSceneLoad()
        {
            _stateMachine.Enter<GameLoopState>();
        }
    }
}
