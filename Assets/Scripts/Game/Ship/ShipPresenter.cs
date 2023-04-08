using Asteroids.Core.Services;
using Asteroids.Core.Settings;
using Asteroids.Inputs;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Asteroids.Game
{
    public sealed class ShipPresenter : IUpdatable
    {
        private readonly IUpdater _updater;
        private readonly ShipModel _model;
        private readonly ShipView _view;
        private readonly IInputSystem _inputSystem;
        private readonly IShipConfig _shipConfig;
        private readonly PlayerInputActions.PlayerActions _inputActions;

        public ShipPresenter(IUpdater updater, ShipModel model, ShipView view, IInputSystem inputSystem, IShipConfig shipConfig)
        {
            _updater = updater;
            _model = model;
            _view = view;
            _inputSystem = inputSystem;
            _shipConfig = shipConfig;
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

            _view.StartDestroy();
        }

        public void Disable()
        {
            _updater.Remove(this);

            _inputActions.Disable();
        }

        public void Move(float deltaTime)
        {
            var movementDirection = _inputActions.Move.ReadValue<Vector2>();

            _model.Movement = _shipConfig.Speed * deltaTime * movementDirection;
        }

        public void RotateLeft(float deltaTime)
        {
            var direction = _inputActions.RotateLeft.ReadValue<float>();
            Rotate(direction, deltaTime);
        }

        public void RotateRight(float deltaTime)
        {
            var direction = _inputActions.RotateRight.ReadValue<float>();
            Rotate(direction, deltaTime);
        }

        public void Tick(float deltaTime)
        {
            if (_inputActions.Move.phase == InputActionPhase.Started)
                Move(deltaTime);

            if (_inputActions.RotateLeft.phase == InputActionPhase.Started)
                RotateLeft(deltaTime);
            else if (_inputActions.RotateRight.phase == InputActionPhase.Started)
                RotateRight(deltaTime);
        }

        private void Rotate(float direction, float deltaTime)
        {
            var rotation = Quaternion.Euler(0f, 0f, direction * _shipConfig.Damping * deltaTime);

            _model.Rotation = rotation.eulerAngles;
        }
    }
}