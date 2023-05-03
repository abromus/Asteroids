using Asteroids.Core;
using Asteroids.Game.Settings;

namespace Asteroids.Game
{
    public sealed class BulletPresenter : IBulletPresenter
    {
        private Float3 _startPosition;
        private bool _isDestroyed;

        private readonly IUpdater _updater;
        private readonly IBulletModel _model;
        private readonly IBulletView _view;
        private readonly IBulletConfig _config;

        public bool IsDestroyed => _isDestroyed;

        public Float3 Position => _model.Position.Value;

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

            _view.Activate();
        }

        public void Destroy()
        {
            var distance = MathUtils.Distance(_startPosition, _model.Position.Value);

            if (distance < _config.MaxDistance)
                return;

            Clear();

            _isDestroyed = true;
        }

        public void Disable()
        {
            Clear();
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

        public void SetRotation(Float3 rotation)
        {
            _model.Rotation.Value = rotation;
        }

        public void Clear()
        {
            _updater.Remove(this);

            _model.Position.Value = Float3.Zero;
            _model.Rotation.Value = Float3.Zero;

            _view.Deactivate();

            _isDestroyed = false;
        }

        private void Move(float deltaTime)
        {
            var delta = MathUtils.TransformDirection(_model.Rotation.Value.Z);

            _model.Position.Value += _config.Speed * deltaTime * delta;

            var distance = MathUtils.Distance(_startPosition, _model.Position.Value);

            if (distance >= _config.MaxDistance)
                _isDestroyed = true;
        }
    }
}
