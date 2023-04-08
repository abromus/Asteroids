using Asteroids.Core.Services;
using Asteroids.Core.Settings;
using UnityEngine;

namespace Asteroids.Core
{
    public sealed class CoreSceneController : MonoBehaviour, ICoroutineRunner
    {
        [SerializeField] private ConfigStorage _configStorage;

        private IGameData _gameData;

        private void Awake()
        {
            _configStorage.Init();

            DontDestroyOnLoad(this);
        }

        public void CreateGameData()
        {
            _gameData = new GameData(this, _configStorage);

            EnterInitState();
        }

        private void EnterInitState()
        {
            _gameData.ServiceStorage.GetStateMachine().Enter<BootstrapState>();
        }
    }
}
