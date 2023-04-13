using Asteroids.Core;
using Asteroids.Game.Settings;

namespace Asteroids.Game
{
    public sealed class BulletPresenter : IBulletPresenter
    {
        private readonly IUpdater _updater;
        private readonly IBulletModel _model;
        private readonly IBulletView _view;
        private readonly IBulletConfig _config;

        private Float3 _startPosition;

        public BulletPresenter(IUpdater updater, IBulletModel model, IBulletView view, IBulletConfig config)
        {
            _updater = updater;
            _model = model;
            _view = view;
            _config = config;

            _model.Position.OnChanged += _view.Move;
            _model.Rotation.OnChanged += _view.Rotate;
        }

        public void Enable()
        {
            _updater.Add(this);
        }

        public void Destroy()
        {
            Disable();

            _view?.StartDestroy();
        }

        public void Disable()
        {
            _updater.Remove(this);
        }

        public void Tick(float deltaTime)
        {
            Move(deltaTime);
        }

        public void SetPosition(Float3 position)
        {
            _model.Position.Value = position;

            _startPosition = position;
        }

        public void SetRotate(Float3 rotation)
        {
            _model.Rotation.Value = rotation;
        }

        private void Move(float deltaTime)
        {
            var delta = MathUtils.TransformDirection(_model.Rotation.Value.Z);

            _model.Position.Value += _config.Speed * deltaTime * delta;

            if (MathUtils.Distance(_startPosition, _model.Position.Value) > _config.MaxDistance)
                Destroy();
        }
    }
}
