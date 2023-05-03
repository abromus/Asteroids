using Asteroids.Core.Settings;
using UnityEngine;
using UnityEngine.UI;

namespace Asteroids.Game.Services
{
    public static class CanvasHelper
    {
        public static Transform CreateCanvas(ICanvasConfig canvasConfig)
        {
            var canvasObject = new GameObject();
            canvasObject.name = canvasConfig.Name;

            AddCanvas(canvasConfig, canvasObject);
            AddCanvasScaler(canvasConfig, canvasObject);
            AddGraphicRaycaster(canvasObject);

            return canvasObject.transform;
        }

        private static void AddCanvas(ICanvasConfig canvasConfig, GameObject canvasObject)
        {
            var canvas = canvasObject.AddComponent<Canvas>();
            canvas.renderMode = canvasConfig.RenderMode;
            canvas.worldCamera = Camera.main;
        }

        private static void AddCanvasScaler(ICanvasConfig canvasConfig, GameObject canvasObject)
        {
            var canvasScaler = canvasObject.AddComponent<CanvasScaler>();
            canvasScaler.uiScaleMode = canvasConfig.ScaleMode;
            canvasScaler.referenceResolution = canvasConfig.ReferenceResolution;
            canvasScaler.matchWidthOrHeight = canvasConfig.MatchWidthOrHeight;
            canvasScaler.referencePixelsPerUnit = canvasConfig.ReferencePixelsPerUnit;
        }

        private static void AddGraphicRaycaster(GameObject canvasObject)
        {
            canvasObject.AddComponent<GraphicRaycaster>();
        }
    }
}
