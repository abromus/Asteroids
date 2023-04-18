using Asteroids.Core;
using Asteroids.Core.Services;
using Asteroids.Game.Initializers;
using Asteroids.Game.Settings;
using UnityEngine;

namespace Asteroids.Game
{
    public sealed class GameSceneController : SceneController, ICoroutineRunner
    {
        [SerializeField] private Camera _cameraPrefab;
        [SerializeField] private ConfigData _configData;

        private Camera _camera;

        private IGame _game;
        private IUpdater _updater;

        private IConfigInitializer _configInitializer;
        private IServiceInitializer _serviceInitializer;
        private IFactoryInitializer _factoryInitializer;

        public override void Run(IGameData gameData)
        {
            base.Run(gameData);

            _game = new Game(gameData);

            _configInitializer = new ConfigInitializer(_game, _configData);
            _configInitializer.Initialize();

            _serviceInitializer = new ServiceInitializer(_game, _updater, _camera);
            _serviceInitializer.Initialize();

            _factoryInitializer = new FactoryInitializer(_game, _updater);
            _factoryInitializer.Initialize();

            _game.Run();
        }

        private void Awake()
        {
            _camera = Instantiate(_cameraPrefab);
            _camera.transform.SetAsFirstSibling();

            _updater = new Updater();
        }

        private void OnDestroy()
        {
            _game.Destroy();
        }

        private void Update()
        {
            _updater.Tick(Time.deltaTime);
        }
    }
}
