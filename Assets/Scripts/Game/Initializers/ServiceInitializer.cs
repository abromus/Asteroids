using Asteroids.Core;
using Asteroids.Core.Services;
using Asteroids.Core.Settings;
using Asteroids.Game.Services;
using UnityEngine;
using Bounds = Asteroids.Core.Bounds;

namespace Asteroids.Game.Initializers
{
    public sealed class ServiceInitializer : IServiceInitializer
    {
        private readonly IGame _game;
        private readonly Camera _camera;

        public ServiceInitializer(IGame game, Camera camera)
        {
            _game = game;
            _camera = camera;
        }

        public void Initialize()
        {
            InitServices();
        }

        private void InitServices()
        {
            var updater = _game.GameData.ServiceStorage.GetUpdater();

            var canvas = CanvasHelper.CreateCanvas(_game.GameData.ConfigStorage.GetCanvasConfig());

            InitInputSystem(canvas);

            InitScreenSystem(updater, canvas);

            InitPositionCheckService(updater);

            InitTimerSystem(updater);
        }

        private void InitInputSystem(Transform parent)
        {
            var uiServices = _game.GameData.ConfigStorage.GetUiServiceConfig().UiServices;
            var inputSystem = uiServices.GetInputSystem();
            inputSystem.Init(parent);

            _game.GameData.ServiceStorage.AddService(inputSystem);
        }

        private void InitScreenSystem(IUpdater updater, Transform parent)
        {
            var bounds = CalculateBounds();

            var uiServices = _game.GameData.ConfigStorage.GetUiServiceConfig().UiServices;
            var screenSystem = uiServices.GetScreenSystem();
            screenSystem.Init(_game.GameData, updater, bounds, parent);

            _game.GameData.ServiceStorage.AddService(screenSystem);
        }

        private Bounds CalculateBounds()
        {
            var cameraPosition = _camera.transform.position.ToFloat3();

            var twice = 2f;
            var width = _camera.orthographicSize * _camera.pixelWidth / _camera.scaledPixelHeight * twice;
            var height = _camera.orthographicSize * twice;
            var size = new Float3(width, height);

            var bounds = new Bounds(cameraPosition, size);

            return bounds;
        }

        private void InitPositionCheckService(IUpdater updater)
        {
            var positionCheckService = new PositionCheckService();

            updater.Add(positionCheckService);

            _game.GameData.ServiceStorage.AddService(positionCheckService as IPositionCheckService);
        }

        private void InitTimerSystem(IUpdater updater)
        {
            var timerService = new TimerService();

            updater.Add(timerService);

            _game.GameData.ServiceStorage.AddService(timerService as ITimerService);
        }
    }
}
