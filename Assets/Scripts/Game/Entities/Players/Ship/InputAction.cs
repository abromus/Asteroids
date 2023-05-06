using Asteroids.Game.Services;

namespace Asteroids.Game
{
    public sealed class InputAction : IInputAction
    {
        private readonly IInputSystem _inputSystem;

        private readonly IDeviceInputAction _deviceInputActions;

        public bool IsMoving => _deviceInputActions.IsMoving();

        public bool IsRotatingLeft => _deviceInputActions.IsRotatingLeft();

        public bool IsRotatingRight => _deviceInputActions.IsRotatingRight();

        public bool IsShooting => _deviceInputActions.IsShooting();

        public InputAction(IInputSystem inputSystem)
        {
            _inputSystem = inputSystem;

#if UNITY_EDITOR
            _deviceInputActions = new KeyboardInputAction(inputSystem);
#else
            _deviceInputActions = new JoystickInputAction(inputSystem);
#endif
        }

        public void Disable()
        {
            _deviceInputActions.Disable();
        }

        public void Enable()
        {
            _deviceInputActions.Enable();
        }
    }
}
