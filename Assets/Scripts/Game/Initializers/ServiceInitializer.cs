﻿using Asteroids.Core;
using Asteroids.Core.Settings;
using Asteroids.Game.Services;
using UnityEngine;
using UnityEngine.UI;
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

            var canvas = CreateCanvas();

            var uiServices = _game.GameData.ConfigStorage.GetUiServiceConfig().UiServices;
            var screenSystem = uiServices.GetScreenSystem();
            screenSystem.Init(_game.GameData, bounds, canvas);

            _game.GameData.ServiceStorage.AddService(screenSystem);
        }

        private Bounds CalculateBounds()
        {
            var upVector = new Float3(0f, _camera.orthographicSize);
            var rightVector = new Float3(_camera.orthographicSize * _camera.pixelWidth / _camera.scaledPixelHeight, 0f);
            var cameraPosition = _camera.transform.position.ToFloat3();

            var left = cameraPosition - rightVector;
            var right = cameraPosition + rightVector;
            var top = cameraPosition + upVector;
            var bottom = cameraPosition - upVector;

            var bounds = new Bounds(left, right, top, bottom);

            return bounds;
        }

        private Transform CreateCanvas()
        {
            var canvasConfig = _game.GameData.ConfigStorage.GetCanvasConfig();

            var canvasObject = new GameObject();
            canvasObject.name = canvasConfig.Name;

            AddCanvas(canvasConfig, canvasObject);
            AddCanvasScaler(canvasConfig, canvasObject);
            AddGraphicRaycaster(canvasObject);

            return canvasObject.transform;
        }

        private void AddCanvas(ICanvasConfig canvasConfig, GameObject canvasObject)
        {
            var canvas = canvasObject.AddComponent<Canvas>();
            canvas.renderMode = canvasConfig.RenderMode;
            canvas.worldCamera = Camera.main;
        }

        private void AddCanvasScaler(ICanvasConfig canvasConfig, GameObject canvasObject)
        {
            var canvasScaler = canvasObject.AddComponent<CanvasScaler>();
            canvasScaler.uiScaleMode = canvasConfig.ScaleMode;
            canvasScaler.referenceResolution = canvasConfig.ReferenceResolution;
            canvasScaler.matchWidthOrHeight = canvasConfig.MatchWidthOrHeight;
            canvasScaler.referencePixelsPerUnit = canvasConfig.ReferencePixelsPerUnit;
        }

        private void AddGraphicRaycaster(GameObject canvasObject)
        {
            canvasObject.AddComponent<GraphicRaycaster>();
        }

        private void InitTimerSystem()
        {
            var timerService = new TimerService();

            _updater.Add(timerService);

            _game.GameData.ServiceStorage.AddService(timerService as ITimerService);
        }
    }
}
