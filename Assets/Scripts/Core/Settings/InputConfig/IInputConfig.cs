using UnityEngine;
using UnityEngine.InputSystem;

namespace Asteroids.Core.Settings
{
    public interface IInputConfig : IConfig
    {
        public InputActionAsset Actions { get; }

        public string DefaultActionMap { get; }

        public PlayerNotifications Behaviour { get; }
    }
}
