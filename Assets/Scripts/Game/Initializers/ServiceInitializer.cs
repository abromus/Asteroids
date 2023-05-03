using Asteroids.Core;
using Asteroids.Core.Settings;
using Asteroids.Game.Services;
using UnityEngine;
using Bounds = Asteroids.Core.Bounds;

namespace Asteroids.Game.Initializers
{
    public sealed class ServiceInitializer : IServiceInitializer
    {
        private readonly IGame _game;
        private readonly IUpdater _updater;
        private readonly Camera _camera;

        public ServiceInitializer(IGame game, IUpdater updater, Camera camera)
        {
            _game = game;
            _updater = updater;
            _camera = camera;
        }

        public void Initialize()
        {
            InitServices();
        }

        private void InitServices()
        {
            InitInputSystem();

            InitScreenSystem();

            InitPositionCheckService();

            InitTimerSystem();
        }

        private void InitInputSystem()
        {
            var uiServices = _game.GameData.ConfigStorage.GetUiServiceConfig().UiServices;
            var inputSystem = uiServices.GetInputSystem();
            inputSystem.Init();

            _game.GameData.ServiceStorage.AddService(inputSystem);
        }

        private void InitScreenSystem()
        {
            var bounds = CalculateBounds();

            var canvas = CanvasHelper.CreateCanvas(_game.GameData.ConfigStorage.GetCanvasConfig());

            var uiServices = _game.GameData.ConfigStorage.GetUiServiceConfig().UiServices;
            var screenSystem = uiServices.GetScreenSystem();
            screenSystem.Init(_game.GameData, _updater, bounds, canvas);

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

        private void InitPositionCheckService()
        {
            var positionCheckService = new PositionCheckService();

            _updater.Add(positionCheckService);

            _game.GameData.ServiceStorage.AddService(positionCheckService as IPositionCheckService);
        }

        private void InitTimerSystem()
        {
            var timerService = new TimerService();

            _updater.Add(timerService);

            _game.GameData.ServiceStorage.AddService(timerService as ITimerService);
        }
    }
}
