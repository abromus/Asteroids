using Asteroids.Core.Settings;
using Asteroids.Inputs;

namespace Asteroids.Core.Services
{
    public sealed class InputSystem : UiService, IInputSystem
    {
        private PlayerInputActions _playerInputActions;

        public override UiServiceType UiServiceType => UiServiceType.InputSystem;

#if UNITY_EDITOR
        public PlayerInputActions.KeyboardActions InputActions => _playerInputActions.Keyboard;
#else
        public PlayerInputActions.JoystickActions InputActions  => _playerInputActions.Joystick;
#endif

        public void Init()
        {
            _playerInputActions = new PlayerInputActions();
        }

        public void Enable()
        {
            _playerInputActions.Enable();
        }

        public void Disable()
        {
            _playerInputActions.Disable();
        }
    }
}
