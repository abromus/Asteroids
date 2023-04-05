using UnityEngine;
using UnityEngine.UI;

namespace Asteroids.Core.Settings
{
    public interface ICanvasConfig : IConfig
    {
        public string Name { get; }

        public RenderMode RenderMode { get; }

        public CanvasScaler.ScaleMode ScaleMode { get; }

        public Vector2 ReferenceResolution { get; }

        public float MatchWidthOrHeight { get; }

        public float ReferencePixelsPerUnit { get; }
    }
}
