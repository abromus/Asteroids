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

        public IMachineGunView View => _view;

        public MachineGunPresenter(IUpdater updater, IMachineGunModel model, IMachineGunView view, IMachineGunConfig config, IBulletFactory bulletFactory)
        {
            _updater = updater;
            _model = model;
            _view = view;
            _config = config;
            _bulletFactory = bulletFactory;

            //_model.OnMovementChanged += _view.Move;
            //_model.OnRotationChanged += _view.Rotate;
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

        public void Rotate(Float3 rotation)
        {
            //_model.Rotation = rotation;
        }

        public void TryShoot()
        {
            var bullet = _bulletFactory.Create();
            //bullet.SetPosition(_model.Position);
            //bullet.SetRotate(_model.Rotation);
            bullet.Enable();
        }
    }
}
