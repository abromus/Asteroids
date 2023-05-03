using System;
using Asteroids.Core;
using Asteroids.Game.Settings;
using Bounds = Asteroids.Core.Bounds;

namespace Asteroids.Game
{
    public sealed class AsteroidPresenter : IAsteroidPresenter
    {
        private bool _isDestroyed;

        private readonly IUpdater _updater;
        private readonly IAsteroidModel _model;
        private readonly IAsteroidView _view;
        private readonly IAsteroidConfig _config;
        private readonly Bounds _bounds;

        public bool IsDestroyed => _isDestroyed;

        public Float3 Position => _model.Position.Value;

        public Action<IAsteroidPresenter> Destroyed { get; set; }

        public AsteroidPresenter(IUpdater updater, IAsteroidModel model, IAsteroidView view, IAsteroidConfig config, Bounds bounds)
        {
            _updater = updater;
            _model = model;
            _view = view;
            _config = config;
            _bounds = bounds;
        }

        public void Init(Float3 position)
        {
            _model.Position.Value = position;

            Rotate();
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

            _model.Position.Value = Float3.Zero;
            _model.Rotation.Value = Float3.Zero;

            Destroyed = null;

            _isDestroyed = true;
        }

        public void Tick(float deltaTime)
        {
            Move(deltaTime);
        }

        public void Clear()
        {
            _updater.Remove(this);

            _view?.Deactivate();

            _isDestroyed = false;
        }

        public void TakeDamage(IDamaging damaging)
        {
            if (damaging is IBulletPresenter)
            {
                Destroyed?.SafeInvoke(this);

                Destroy();
            }
            else if(damaging is ILaserPresenter)
            {
                Destroy();
            }
        }

        private void Move(float deltaTime)
        {
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
            var angle = MathUtils.Value * MathUtils.FullAngle;
            var rotation = MathUtils.CalculateRotation(angle, _model.Rotation.Value);

            _model.Rotation.Value = rotation;
        }
    }
}
