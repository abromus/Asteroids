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
                Shoot(deltaTime);
        }

        private void Move(float deltaTime)
        {
            var delta = TransformDirection(_model.Rotation.Value);

            _model.Position.Value += _config.Speed * deltaTime * delta;
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
            var eulerAngles = new Vector3(0f, 0f, direction * _config.Damping * deltaTime);
            var delta = Quaternion.Euler(eulerAngles);

            var rotation = (_model.Rotation.Value + delta.eulerAngles.ToFloat3()) % MathUtils.FullAngle;

            if (rotation.Z >= MathUtils.HalfAngle)
                rotation.Z -= MathUtils.FullAngle;

            _model.Rotation.Value = rotation;

            _machineGunPresenter.Rotate(_model.Rotation.Value);
        }

        private void Shoot(float deltaTime)
        {
            Debug.LogError($"Shoot");

            _machineGunPresenter.TryShoot();
        }

        private Float3 TransformDirection(Float3 angle)
        {
            var x = Mathf.Sin(angle.Z * Mathf.Deg2Rad);
            var y = Mathf.Cos(angle.Z * Mathf.Deg2Rad);

            if (Mathf.Abs(angle.Z) <= MathUtils.HalfAngle)
                x = -x;

            var result = new Float3(x, y);

            return result;
        }
    }
}
