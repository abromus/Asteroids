using Asteroids.Core.Settings;
using UnityEngine.InputSystem;

namespace Asteroids.Game.Settings
{
    public interface IInputConfig : IConfig
    {
        public InputActionAsset Actions { get; }

        public PlayerNotifications Behaviour { get; }
    }
}
