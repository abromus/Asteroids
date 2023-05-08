using Asteroids.Core;
using Asteroids.Core.Services;

namespace Asteroids.Game
{
    public abstract class Projectile : IUpdatable
    {
        private Float3 _startPosition;
        private bool _isDestroyed;

        private readonly IUpdater _updater;
        private readonly IModel _model;
        private readonly IView _view;
        private readonly float _maxDistance;
        private readonly float _speed;

        public bool IsDestroyed => _isDestroyed;

        public Float3 Position => _model.Position.Value;


        public Projectile(IUpdater updater, IModel model, IView view, float maxDistance, float speed)
        {
            _updater = updater;
            _model = model;
            _view = view;
            _maxDistance = maxDistance;
            _speed = speed;

            _model.Position.OnChanged += _view.Move;
            _model.Rotation.OnChanged += _view.Rotate;
        }

        public void Enable()
        {
            _updater.Add(this);

            _view.Activate();
        }

        public void Disable()
        {
            Clear();
        }

        public void Destroy()
        {
            Clear();

            _isDestroyed = true;
        }

        public void Clear()
        {
            _updater.Remove(this);

            _model.Position.Value = Float3.Zero;
            _model.Rotation.Value = Float3.Zero;

            _view.Deactivate();

            _isDestroyed = false;
        }

        public void Tick(float deltaTime)
        {
            Move(deltaTime);

            CheckPosition();
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

        private void Move(float deltaTime)
        {
            var delta = MathUtils.TransformDirection(_model.Rotation.Value.Z);

            _model.Position.Value += _speed * deltaTime * delta;
        }

        private void CheckPosition()
        {
            var distance = MathUtils.Distance(_startPosition, _model.Position.Value);

            if (distance >= _maxDistance)
                _isDestroyed = true;
        }
    }
}
