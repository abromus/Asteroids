using Asteroids.Inputs;
using Asteroids.Core.Settings;

namespace Asteroids.Core.Services
{
    public interface IInputSystem : IService
    {
        public PlayerInputActions.PlayerActions InputActions { get; }

        public void Disable();

        public void Enable();

        public void Init(IInputConfig inputConfig);
    }
}
