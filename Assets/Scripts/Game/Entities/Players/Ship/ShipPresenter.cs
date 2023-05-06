using System;
using Asteroids.Core;
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
        }

        public void Destroy()
        {
            Disable();

            _view.DestroyView();

            _isDestroyed = true;

            Destroyed.SafeInvoke();
            Destroyed = null;
        }

        public void Disable()
        {
            _updater.Remove(this);

            _inputActions.Disable();
        }

        public void Tick(float deltaTime)
        {
            if (_inputActions.IsMoving)
                _acceleration.SpeedUp(deltaTime);
            else
                _acceleration.SlowDown(deltaTime);

            Move(deltaTime);

            if (_inputActions.IsRotatingLeft)
                Rotate(deltaTime, true);
            else if (_inputActions.IsRotatingRight)
                Rotate(deltaTime, false);

            if (_inputActions.IsShooting)
                Shoot();
        }

        public void TakeDamage(IDamaging damaging)
        {
            if (damaging is IAsteroidPresenter || damaging is IFlyingSaucerPresenter)
                Destroy();
        }

        private void Move(float deltaTime)
        {
            var direction = MathUtils.TransformDirection(_model.Rotation.Value.Z);
            var delta = _acceleration.Speed * deltaTime * direction;
            var modelPosition = MathUtils.CorrectPosition(_model.Position.Value + delta, _bounds);

            var machineGunPosition = _model.Position.Value + delta == modelPosition
                ? _machineGunPresenter.Position - _machineGunPresenter.Offset + delta
                : MathUtils.CorrectPosition(_machineGunPresenter.Position + delta, _bounds) - _machineGunPresenter.Offset;
            var laserGunPosition = _model.Position.Value + delta == modelPosition
                ? _laserGunPresenter.Position - _laserGunPresenter.Offset + delta
                : MathUtils.CorrectPosition(_laserGunPresenter.Position + delta, _bounds) - _laserGunPresenter.Offset;

            _machineGunPresenter.SetPosition(machineGunPosition);
            _laserGunPresenter.SetPosition(laserGunPosition);
            _model.Position.Value = modelPosition;
        }

        private void Rotate(float deltaTime, bool isLeft)
        {
            var direction = isLeft ? 1f : -1f;
            var angle = direction * _config.Damping * deltaTime;
            var rotation = MathUtils.CalculateRotation(angle, _model.Rotation.Value);

            var deltaMachineGunPosition = MathUtils.Rotate(
                _model.Position.Value,
                _machineGunPresenter.Position,
                rotation.Z - _model.Rotation.Value.Z);

            var deltaLaserGunPosition = MathUtils.Rotate(
                _model.Position.Value,
                _laserGunPresenter.Position,
                rotation.Z - _model.Rotation.Value.Z);

            _model.Rotation.Value = rotation;

            _machineGunPresenter.SetPosition(_model.Position.Value + deltaMachineGunPosition - _machineGunPresenter.Offset);
            _machineGunPresenter.SetRotation(rotation);

            _laserGunPresenter.SetPosition(_model.Position.Value + deltaLaserGunPosition - _laserGunPresenter.Offset);
            _laserGunPresenter.SetRotation(rotation);
        }

        private void Shoot()
        {
            _laserGunPresenter.TryShoot();
            _machineGunPresenter.TryShoot();
        }
    }
}
