using Asteroids.Core.Services;

namespace Asteroids.Core.States
{
    public sealed class BootstrapState : IEnterState
    {
        private readonly IStateMachine _stateMachine;

        public BootstrapState(IStateMachine stateMachine)
        {
            _stateMachine = stateMachine;
        }

        public void Enter()
        {
            var coreSceneInfo = new SceneInfo(SceneKeys.CoreSceneName, OnSceneLoad);

            _stateMachine.Enter<SceneLoaderState, SceneInfo>(coreSceneInfo);
        }

        public void Exit() { }

        private void OnSceneLoad()
        {
            _stateMachine.Enter<GameState>();
        }
    }
}
