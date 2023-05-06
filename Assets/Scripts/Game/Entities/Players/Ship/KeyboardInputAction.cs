#if UNITY_EDITOR
using Asteroids.Core.Services;
using Asteroids.Inputs;
using UnityEngine.InputSystem;

namespace Asteroids.Game
{
    public sealed class KeyboardInputAction : IDeviceInputAction
    {
        private readonly PlayerInputActions.KeyboardActions _inputActions;

        public KeyboardInputAction(IInputSystem inputSystem)
        {
            _inputActions = inputSystem.InputActions;
        }

        public void Disable()
        {
            _inputActions.Disable();
        }

        public void Enable()
        {
            _inputActions.Enable();
        }

        public bool IsMoving()
        {
            return _inputActions.Move.phase == InputActionPhase.Started;
        }

        public bool IsRotatingLeft()
        {
            return _inputActions.RotateLeft.phase == InputActionPhase.Started;
        }

        public bool IsRotatingRight()
        {
            return _inputActions.RotateRight.phase == InputActionPhase.Started;
        }

        public bool IsShooting()
        {
            return _inputActions.Shoot.phase == InputActionPhase.Performed;
        }
    }
}
#endif
