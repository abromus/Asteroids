using System;
using Asteroids.Core;
using Asteroids.Core.Services;
using Asteroids.Game.Input;
using Asteroids.Game.Services;
using Asteroids.Game.Settings;

namespace Asteroids.Game
{
    public sealed class ShipPresenter : IShipPresenter
    {
        private bool _isDestroyed;

        private readonly IUpdater _updater;
        private readonly IShipModel _model;
        private readonly IShipView _view;
        private readonly IShipConfig _config;
        private readonly Bounds _bounds;
        private readonly IMachineGunPresenter _machineGunPresenter;
        private readonly ILaserGunPresenter _laserGunPresenter;

        private readonly IInputAction _inputActions;

        private readonly IAcceleration _acceleration;

        public float Acceleration => _acceleration.Speed;

        public int LasersCount => _laserGunPresenter.LasersCount;

        public float LasersReloadTime => _laserGunPresenter.ReloadTime;

        public Float3 Position => _model.Position.Value;

        public Float3 Rotation => _model.Rotation.Value;

        public bool IsDestroyed => _isDestroyed;

        public Action Destroyed { get; set; }

        public ShipPresenter(
            IUpdater updater,
            IShipModel model,
            IShipView view,
            IShipConfig config,
            IInputSystem inputSystem,
            Bounds bounds,
            IMachineGunPresenter machineGunPresenter,
            ILaserGunPresenter laserGunPresenter)
        {
            _updater = updater;
            _model = model;
            _view = view;
            _config = config;

            _inputActions = new InputAction(inputSystem);
            _bounds = bounds;

            _machineGunPresenter = machineGunPresenter;
            _laserGunPresenter = laserGunPresenter;
            _acceleration = new Acceleration(_config.Speed);

            _model.Position.OnChanged += _view.Move;
            _model.Rotation.OnChanged += _view.Rotate;
        }

        public void Enable()
        {
            _updater.Add(this);

            _inputActions.Enable();

            _machineGunPresenter.Enable();
            _laserGunPresenter.Enable();
        }

        public void Disable()
        {
            _updater.Remove(this);

            _inputActions.Disable();

            _machineGunPresenter.Disable();
            _laserGunPresenter.Disable();
        }

        public void Destroy()
        {
            Disable();

            _view.DestroyView();

            _machineGunPresenter.Destroy();
            _laserGunPresenter.Destroy();

            _isDestroyed = true;

            Destroyed.SafeInvoke();
            Destroyed = null;
        }

        public void Tick(float deltaTime)
        {
            ChangeSpeed(deltaTime);

            Move(deltaTime);

            ChangeRotation(deltaTime);

            TryShoot();
        }

        public void TakeDamage(IDamaging damaging)
        {
            if (damaging is IAsteroidPresenter or IFlyingSaucerPresenter)
                Destroy();
        }

        private void ChangeSpeed(float deltaTime)
        {
            if (_inputActions.IsMoving)
                _acceleration.SpeedUp(deltaTime);
            else
                _acceleration.SlowDown(deltaTime);
        }

        private void Move(float deltaTime)
        {
            var direction = MathUtils.TransformDirection(_model.Rotation.Value.Z);
            var delta = _acceleration.Speed * deltaTime * direction;
            var modelPosition = MathUtils.CorrectPosition(_model.Position.Value + delta, _bounds);

            SetGunPosition(_machineGunPresenter, delta, modelPosition);
            SetGunPosition(_laserGunPresenter, delta, modelPosition);

            _model.Position.Value = modelPosition;
        }

        private void ChangeRotation(float deltaTime)
        {
            if (_inputActions.IsRotatingLeft)
                Rotate(deltaTime, true);
            else if (_inputActions.IsRotatingRight)
                Rotate(deltaTime, false);
        }

        private void TryShoot()
        {
            if (!_inputActions.IsShooting)
                return;

            _laserGunPresenter.TryShoot();
            _machineGunPresenter.TryShoot();
        }

        private void Rotate(float deltaTime, bool isLeft)
        {
            var direction = isLeft ? 1f : -1f;
            var angle = direction * _config.AngularVelocity * deltaTime;
            var rotation = MathUtils.CalculateRotation(angle, _model.Rotation.Value);

            RotateGun(_machineGunPresenter, rotation);
            RotateGun(_laserGunPresenter, rotation);

            _model.Rotation.Value = rotation;
        }

        private void RotateGun(IGunPresenter gunPresenter, Float3 rotation)
        {
            SetGunPosition(gunPresenter, rotation);
            gunPresenter.SetRotation(rotation);
        }

        private void SetGunPosition(IGunPresenter gunPresenter, Float3 delta, Float3 modelPosition)
        {
            var gunPosition = _model.Position.Value + delta == modelPosition
                ? gunPresenter.Position - gunPresenter.Offset + delta
                : MathUtils.CorrectPosition(gunPresenter.Position + delta, _bounds) - gunPresenter.Offset;

            gunPresenter.SetPosition(gunPosition);
        }

        private void SetGunPosition(IGunPresenter gunPresenter, Float3 rotation)
        {
            var deltaGunPosition = MathUtils.Rotate(
                _model.Position.Value,
                gunPresenter.Position,
                rotation.Z - _model.Rotation.Value.Z);

            gunPresenter.SetPosition(_model.Position.Value + deltaGunPosition - gunPresenter.Offset);
        }
    }
}
