using Asteroids.Settings;
using UnityEngine;

namespace Asteroids.Core.Services
{
    public sealed class ScreenSystem : UiService, IScreenSystem
    {
        private Transform _transform;

        public override UiServiceType UiServiceType => UiServiceType.ScreenSystem;

        public void Init(Transform transform)
        {
            _transform = transform;
        }
    }
}
