using Asteroids.Core;
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
        private readonly IMachineGunPresenter _machineGunPresenter;

        private readonly PlayerInputActions.PlayerActions _inputActions;

        public ShipPresenter(IUpdater updater, IShipModel model, IShipView view, IShipConfig config, IInputSystem inputSystem, IMachineGunPresenter machineGunPresenter)
        {
            _updater = updater;
            _model = model;
            _view = view;
            _config = config;

            _inputSystem = inputSystem;
            _inputActions = _inputSystem.InputActions;

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

            _model.Position.Value += delta;

            _machineGunPresenter.SetPosition(_machineGunPresenter.Position + delta - _machineGunPresenter.Offset);
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
            var rotation = CalculateRotation(direction, deltaTime);
            var deltaPosition = CalculateRotationOffset(rotation);

            _model.Rotation.Value = rotation;

            _machineGunPresenter.SetPosition(_model.Position.Value + deltaPosition - _machineGunPresenter.Offset);

            _machineGunPresenter.SetRotation(rotation);
        }

        private Float3 CalculateRotation(float direction, float deltaTime)
        {
            var eulerAngles = new Vector3(0f, 0f, direction * _config.Damping * deltaTime);
            var delta = Quaternion.Euler(eulerAngles);

            var rotation = (_model.Rotation.Value + delta.eulerAngles.ToFloat3()) % MathUtils.FullAngle;

            if (rotation.Z >= MathUtils.HalfAngle)
                rotation.Z -= MathUtils.FullAngle;

            return rotation;
        }

        private Float3 CalculateRotationOffset(Float3 rotation)
        {
            var centralPoint = _model.Position.Value;
            var pivotPoint = _machineGunPresenter.Position;

            var deltaPosition = MathUtils.Rotate(centralPoint, pivotPoint, rotation.Z - _model.Rotation.Value.Z);
            
            return deltaPosition;
        }

        private void Shoot()
        {
            _machineGunPresenter.TryShoot();
        }
    }
}
