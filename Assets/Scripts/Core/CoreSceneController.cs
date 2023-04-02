using Asteroids.Core.Services;
using Asteroids.Settings;
using UnityEngine;

namespace Asteroids.Core
{
    public sealed class CoreSceneController : MonoBehaviour, ICoroutineRunner
    {
        [SerializeField] private ConfigStorage _configStorage;

        private IGame _game;

        private void Awake()
        {
            _configStorage.Init();

            DontDestroyOnLoad(this);
        }

        public void CreateGame()
        {
            _game = new Game(this, _configStorage);

            EnterInitState();
        }

        private void EnterInitState()
        {
            _game.ServiceStorage.GetService<IStateMachine>().Enter<BootstrapState>();
        }

        private void OnDestroy()
        {
            _game?.Destroy();
        }
    }
}
