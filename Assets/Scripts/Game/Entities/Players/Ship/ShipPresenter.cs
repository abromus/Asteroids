using Asteroids.Core;
using Asteroids.Core.Services;
using Asteroids.Game.Services;
using Asteroids.Game.Settings;
using Asteroids.Inputs;
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
        private readonly IScreenSystem _screenSystem;
        private readonly IMachineGunPresenter _machineGunPresenter;

        private readonly PlayerInputActions.PlayerActions _inputActions;

        public ShipPresenter(IUpdater updater, IShipModel model, IShipView view, IShipConfig config, IInputSystem inputSystem, IScreenSystem screenSystem, IMachineGunPresenter machineGunPresenter)
        {
            _updater = updater;
            _model = model;
            _view = view;
            _config = config;

            _inputSystem = inputSystem;
            _inputActions = _inputSystem.InputActions;
            _screenSystem = screenSystem;

            _machineGunPresenter = machineGunPresenter;

            _model.Position.OnChanged += _view.Move;
            _model.Rotation.OnChanged += _view.Rotate;
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
                Shoot();
        }

        private void Move(float deltaTime)
        {
            var direction = MathUtils.TransformDirection(_model.Rotation.Value.Z);

            var delta = _config.Speed * deltaTime * direction;

            var modelPosition = CorrectPosition(_model.Position.Value + delta);
            var machineGunPosition = CorrectPosition(_machineGunPresenter.Position + delta) - _machineGunPresenter.Offset;

            _model.Position.Value = modelPosition;

            _machineGunPresenter.SetPosition(machineGunPosition);
        }

        private Float3 CorrectPosition(Float3 original)
        {
            var x = original.X > _screenSystem.Bounds.Right.X
                ? _screenSystem.Bounds.Left.X
                : original.X < _screenSystem.Bounds.Left.X
                    ? _screenSystem.Bounds.Right.X
                    : original.X;

            var y = original.Y > _screenSystem.Bounds.Top.Y
                ? _screenSystem.Bounds.Bottom.Y
                : original.Y < _screenSystem.Bounds.Bottom.Y
                    ? _screenSystem.Bounds.Top.Y
                    : original.Y;

            var z = original.Z;

            var position = new Float3(x, y, z);

            return position;
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
            var angle = direction * _config.Damping * deltaTime;
            var rotation = MathUtils.CalculateRotation(angle, _model.Rotation.Value);
            var deltaPosition = MathUtils.Rotate(
                _model.Position.Value,
                _machineGunPresenter.Position,
                rotation.Z - _model.Rotation.Value.Z);

            _model.Rotation.Value = rotation;

            _machineGunPresenter.SetPosition(_model.Position.Value + deltaPosition - _machineGunPresenter.Offset);

            _machineGunPresenter.SetRotation(rotation);
        }

        private void Shoot()
        {
            _machineGunPresenter.TryShoot();
        }
    }
}
