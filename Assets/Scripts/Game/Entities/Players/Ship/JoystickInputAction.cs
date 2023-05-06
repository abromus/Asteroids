#if !UNITY_EDITOR
using Asteroids.Game.Services;
using Asteroids.Inputs;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Asteroids.Game
{
    public sealed class JoystickInputAction : IDeviceInputAction
    {
        private const float Offset = 0.5f;

        private readonly PlayerInputActions.JoystickActions _inputActions;

        public JoystickInputAction(IInputSystem inputSystem)
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
            return _inputActions.Move.phase == InputActionPhase.Started && _inputActions.Move.ReadValue<Vector2>().y > Offset;
        }

        public bool IsRotatingLeft()
        {
            return _inputActions.Move.phase == InputActionPhase.Started && _inputActions.Move.ReadValue<Vector2>().x <= -Offset;
        }

        public bool IsRotatingRight()
        {
            return _inputActions.Move.phase == InputActionPhase.Started && _inputActions.Move.ReadValue<Vector2>().x >= Offset;
        }

        public bool IsShooting()
        {
            return _inputActions.Shoot.triggered;
        }
    }
}
#endif
