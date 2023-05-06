using Asteroids.Inputs;

namespace Asteroids.Core.Services
{
    public interface IInputSystem : IService
    {
#if UNITY_EDITOR
        public PlayerInputActions.KeyboardActions InputActions { get; }
#else
        public PlayerInputActions.JoystickActions InputActions { get; }
#endif

        public void Disable();

        public void Enable();

        public void Init();
    }
}
