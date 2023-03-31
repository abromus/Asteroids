using Asteroids.Core.Services;
using UnityEngine;

namespace Asteroids.Core
{
    public sealed class CoreSceneController : MonoBehaviour, ICoroutineRunner
    {
        private IStateMachine _stateMachine;

        private void Awake()
        {
            _stateMachine = new StateMachine(new SceneLoader(this));

            DontDestroyOnLoad(this);
        }

        public void CreateGame()
        {
            EnterInitState();
        }

        private void EnterInitState()
        {
            _stateMachine.Enter<BootstrapState>();
        }
    }
}
