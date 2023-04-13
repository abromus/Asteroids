using Asteroids.Core;
using Asteroids.Game.Settings;
using UnityEngine;

namespace Asteroids.Game
{
    public sealed class AsteroidPresenter : IAsteroidPresenter
    {
        private readonly IUpdater _updater;
        private readonly IAsteroidModel _model;
        private readonly IAsteroidView _view;
        private readonly IAsteroidConfig _config;

        public AsteroidPresenter(IUpdater updater, IAsteroidModel model, IAsteroidView view, IAsteroidConfig config)
        {
            _updater = updater;
            _model = model;
            _view = view;
            _config = config;

            _model.Position.OnChanged += _view.Move;
            _model.Rotation.OnChanged += _view.Rotate;
        }

        public void Init(Float3 position)
        {
            _model.Position.Value = position;

            Rotate();
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
            Move(deltaTime);
        }

        private void Move(float deltaTime)
        {
            var direction = MathUtils.TransformDirection(_model.Rotation.Value.Z);

            var delta = _config.Speed * deltaTime * direction;

            _model.Position.Value += delta;
        }

        private void Rotate()
        {
            var angle = Random.value * MathUtils.FullAngle;

            var rotation = MathUtils.CalculateRotation(angle, _model.Rotation.Value);

            _model.Rotation.Value = rotation;
        }
    }
}
