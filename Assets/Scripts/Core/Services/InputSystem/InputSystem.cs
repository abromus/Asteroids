using Asteroids.Inputs;
using Asteroids.Core.Settings;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Asteroids.Core.Services
{
    public sealed class InputSystem : UiService, IInputSystem
    {
        [SerializeField] private PlayerInput _playerInputPrefab;

        private IInputConfig _inputConfig;
        private PlayerInputActions _playerInputActions;

        public override UiServiceType UiServiceType => UiServiceType.InputSystem;

        public PlayerInputActions.PlayerActions InputActions => _playerInputActions.Player;

        public void Init(IInputConfig inputConfig)
        {
            _inputConfig = inputConfig;
            _playerInputActions = new PlayerInputActions();

            CreatePlayerInput();
        }

        public void Enable()
        {
            _playerInputActions.Enable();
        }

        public void Disable()
        {
            _playerInputActions.Disable();
        }

        private void CreatePlayerInput()
        {
            var playerInput = Instantiate(_playerInputPrefab);
            playerInput.actions = _inputConfig.Actions;
            playerInput.SwitchCurrentActionMap(_inputConfig.DefaultActionMap);
            playerInput.notificationBehavior = _inputConfig.Behaviour;
        }
    }
}
