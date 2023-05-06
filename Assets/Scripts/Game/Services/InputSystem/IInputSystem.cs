using Asteroids.Core.Services;
using Asteroids.Inputs;
using UnityEngine;

namespace Asteroids.Game.Services
{
    public interface IInputSystem : IService
    {
#if UNITY_EDITOR
        public PlayerInputActions.KeyboardActions InputActions { get; }
#else
        public PlayerInputActions.JoystickActions InputActions { get; }
#endif

        public void Init(Transform parent);

        public void Hide();

        public void Show();
    }
}
