using Asteroids.Core.Services;
using Asteroids.Game.Settings;
using Asteroids.Inputs;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Asteroids.Game
{
    public sealed class ShipPresenter : IShipPresenter
    {
        private readonly IUpdater _updater;
        private readonly IShipModel _model;
        private readonly IShipView _view;
        private readonly IShipConfig _config;
        private readonly IInputSystem _inputSystem;
        private readonly PlayerInputActions.PlayerActions _inputActions;

        public ShipPresenter(IUpdater updater, IShipModel model, IShipView view, IShipConfig config, IInputSystem inputSystem)
        {
            _updater = updater;
            _model = model;
            _view = view;
            _config = config;

            _inputSystem = inputSystem;
            _inputActions = _inputSystem.InputActions;

            _model.OnMovementChanged += _view.Move;
            _model.OnRotationChanged += _view.Rotate;
        }

        public void Enable()
        {
            _updater.Add(this);

            _inputActions.Enable();
        }

        public void Destroy()
        {
            Disable();
        }

        public void Disable()
        {
            _updater.Remove(this);

            _inputActions.Disable();
        }

        public void Tick(float deltaTime)
        {
            if (_inputActions.Move.phase == InputActionPhase.Started)
                Move(deltaTime);

            if (_inputActions.RotateLeft.phase == InputActionPhase.Started)
                RotateLeft(deltaTime);
            else if (_inputActions.RotateRight.phase == InputActionPhase.Started)
                RotateRight(deltaTime);

            if (_inputActions.Shoot.phase == InputActionPhase.Performed)
                Shoot(deltaTime);
        }

        private void Move(float deltaTime)
        {
            var movementDirection = _inputActions.Move.ReadValue<Vector2>();

            _model.Movement = _config.Speed * deltaTime * movementDirection;
        }

        private void RotateLeft(float deltaTime)
        {
            var direction = _inputActions.RotateLeft.ReadValue<float>();

            Rotate(direction, deltaTime);
        }

        private void RotateRight(float deltaTime)
        {
            var direction = _inputActions.RotateRight.ReadValue<float>();

            Rotate(direction, deltaTime);
        }

        private void Rotate(float direction, float deltaTime)
        {
            var rotation = Quaternion.Euler(0f, 0f, direction * _config.Damping * deltaTime);

            _model.Rotation = rotation.eulerAngles;
        }

        private void Shoot(float deltaTime)
        {
            Debug.LogError($"Shoot");
        }
    }
}
