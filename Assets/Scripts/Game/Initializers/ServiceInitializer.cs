using System.Linq;
using Asteroids.Core;
using Asteroids.Core.Services;
using Asteroids.Core.Settings;
using Asteroids.Game.Services;
using UnityEngine;
using UnityEngine.UI;

namespace Asteroids.Game.Initializers
{
    public sealed class ServiceInitializer : IServiceInitializer
    {
        private readonly IGame _game;

        public ServiceInitializer(IGame game)
        {
            _game = game;
        }

        public void Initialize()
        {
            InitServices();
        }

        private void InitServices()
        {
            InitInputSystem();

            InitScreenSystem();
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
            var canvas = CreateCanvas();

            var uiServices = _game.GameData.ConfigStorage.GetUiServiceConfig().UiServices;
            var screenSystem = uiServices.GetScreenSystem();
            screenSystem.Init(_game.GameData, canvas);

            _game.GameData.ServiceStorage.AddService(screenSystem);
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
    }
}
