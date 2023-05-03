using Asteroids.Core;
using Asteroids.Game.Settings;
using Bounds = Asteroids.Core.Bounds;

namespace Asteroids.Game
{
    public sealed class FlyingSaucerPresenter : IFlyingSaucerPresenter
    {
        private IShipPresenter _shipPresenter;

        private bool _isDestroyed;

        private readonly IUpdater _updater;
        private readonly IFlyingSaucerModel _model;
        private readonly IFlyingSaucerView _view;
        private readonly IFlyingSaucerConfig _config;
        private readonly Bounds _bounds;

        public bool IsDestroyed => _isDestroyed;

        public Float3 Position => _model.Position.Value;

        public FlyingSaucerPresenter(IUpdater updater, IFlyingSaucerModel model, IFlyingSaucerView view, IFlyingSaucerConfig config, Bounds bounds)
        {
            _updater = updater;
            _model = model;
            _view = view;
            _config = config;
            _bounds = bounds;
        }

        public void Init(Float3 position, IShipPresenter shipPresenter)
        {
            _shipPresenter = shipPresenter;

            _model.Position.Value = position;

            var first = _shipPresenter.Position.X < _model.Position.Value.X ? _model.Position.Value : _shipPresenter.Position;
            var second = _shipPresenter.Position.X < _model.Position.Value.X ? _shipPresenter.Position : _model.Position.Value;

            var deltaPosition = first - second;
            var angle = MathUtils.CalculateAngle(Float3.Up, deltaPosition);

            var rotation = MathUtils.CalculateRotation(-angle, Float3.Zero);

            _model.Rotation.Value = rotation;
            _view.Rotate(rotation);
        }

        public void Enable()
        {
            _model.Position.OnChanged += _view.Move;
            _model.Rotation.OnChanged += _view.Rotate;

            _updater.Add(this);

            _view.Activate();
        }

        public void Disable()
        {
            _model.Position.OnChanged -= _view.Move;
            _model.Rotation.OnChanged -= _view.Rotate;

            Clear();
        }

        public void Destroy()
        {
            Clear();

            _isDestroyed = true;
        }

        public void Tick(float deltaTime)
        {
            Move(deltaTime);
        }

        public void Clear()
        {
            _updater.Remove(this);

            _shipPresenter = null;

            _model.Position.OnChanged -= _view.Move;
            _model.Rotation.OnChanged -= _view.Rotate;

            _model.Position.Value = Float3.Zero;
            _model.Rotation.Value = Float3.Zero;

            _view?.Deactivate();

            _isDestroyed = false;
        }

        public void TakeDamage(IDamaging damaging)
        {
            if (damaging is IBulletPresenter or ILaserPresenter)
                Destroy();
        }

        private void Move(float deltaTime)
        {
            Rotate();

            if (_isDestroyed)
                return;

            var direction = MathUtils.TransformDirection(_model.Rotation.Value.Z);
            var delta = _config.Speed * deltaTime * direction;
            var modelPosition = MathUtils.CorrectPosition(_model.Position.Value + delta, _bounds);

            if (_model.Position.Value + delta == modelPosition)
                _model.Position.Value += delta;
            else
                Destroy();
        }

        private void Rotate()
        {
            var destroyDistance = 0.5f;

            var first = _shipPresenter.Position.X < _model.Position.Value.X ? _model.Position.Value : _shipPresenter.Position;
            var second = _shipPresenter.Position.X < _model.Position.Value.X ? _shipPresenter.Position : _model.Position.Value;

            if (MathUtils.Distance(first, second) <= destroyDistance)
                return;

            first = _shipPresenter.Position.X < _model.Position.Value.X ? _model.Position.Value : _shipPresenter.Position;
            second = _shipPresenter.Position.X < _model.Position.Value.X ? _shipPresenter.Position : _model.Position.Value;

            var deltaPosition = first - second;
            var angle = MathUtils.CalculateAngle(Float3.Up, deltaPosition);
            var resultAngle = _shipPresenter.Position.X < _model.Position.Value.X ? MathUtils.HalfAngle - angle : -angle;
            var rotation = MathUtils.CalculateRotation(resultAngle, Float3.Zero);

            _model.Rotation.Value = rotation;
        }
    }
}
