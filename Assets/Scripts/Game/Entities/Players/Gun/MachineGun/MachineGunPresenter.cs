using Asteroids.Core;
using Asteroids.Game.Factory;
using Asteroids.Game.Settings;

namespace Asteroids.Game
{
    public sealed class MachineGunPresenter : IMachineGunPresenter
    {
        private readonly IUpdater _updater;
        private readonly IMachineGunModel _model;
        private readonly IMachineGunView _view;
        private readonly IMachineGunConfig _config;
        private readonly IBulletFactory _bulletFactory;

        private Float3 _offset;

        public Float3 Position => _model.Position.Value;

        public Float3 Offset => _offset;

        public IMachineGunView View => _view;

        public MachineGunPresenter(IUpdater updater, IMachineGunModel model, IMachineGunView view, IMachineGunConfig config, IBulletFactory bulletFactory)
        {
            _updater = updater;
            _model = model;
            _view = view;
            _config = config;
            _bulletFactory = bulletFactory;

            _offset = _config.Offset.ToFloat3();
        }

        public void Enable()
        {
            _updater.Add(this);
        }

        public void Destroy()
        {
            Disable();
        }

        public void Disable()
        {
            _updater.Remove(this);
        }

        public void Tick(float deltaTime)
        {
        }

        public void SetPosition(Float3 position)
        {
            _model.Position.Value = position + _offset;
        }

        public void SetRotation(Float3 rotation)
        {
            _model.Rotation.Value = rotation;
        }

        public void TryShoot()
        {
            var bullet = _bulletFactory.Create();
            bullet.SetRotate(_model.Rotation.Value);
            bullet.SetPosition(_model.Position.Value);
            bullet.Enable();
        }
    }
}
