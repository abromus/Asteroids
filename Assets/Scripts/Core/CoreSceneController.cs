using Asteroids.Core.Services;
using Asteroids.Core.Settings;
using Asteroids.Core.States;
using UnityEngine;

namespace Asteroids.Core
{
    public sealed class CoreSceneController : MonoBehaviour, ICoroutineRunner
    {
        [SerializeField] private ConfigStorage _configStorage;

        private IUpdater _updater;
        private IGameData _gameData;

        public void CreateGameData()
        {
            _updater = new Updater();
            _gameData = new GameData(this, _configStorage, _updater);

            EnterInitState();
        }

        public void Destroy()
        {
            _gameData.Destroy();
        }

        private void Awake()
        {
            _configStorage.Init();

            DontDestroyOnLoad(this);
        }

        private void Update()
        {
            _updater.Tick(Time.deltaTime);
        }

        private void EnterInitState()
        {
            _gameData.ServiceStorage.GetStateMachine().Enter<BootstrapState>();
        }

        private void OnDestroy()
        {
            Destroy();
        }
    }
}
