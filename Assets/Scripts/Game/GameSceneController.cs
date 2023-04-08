using System.Linq;
using Asteroids.Core;
using Asteroids.Core.Services;
using Asteroids.Core.Settings;
using Asteroids.Game.Services;
using UnityEngine;
using UnityEngine.UI;

namespace Asteroids.Game
{
    public sealed class GameSceneController : SceneController, ICoroutineRunner
    {
        private IGame _game;

        public override void Run(IGameData gameData)
        {
            base.Run(gameData);

            _game = new Game(gameData);

            InitScreenSystem();

            _game.Run();
        }

        private void InitScreenSystem()
        {
            var canvas = CreateCanvas();

            var uiServices = _game.GameData.ConfigStorage.GetUiServiceConfig().UiServices;
            var screenSystem = uiServices.FirstOrDefault(service => service.UiServiceType == UiServiceType.ScreenSystem) as IScreenSystem;
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
