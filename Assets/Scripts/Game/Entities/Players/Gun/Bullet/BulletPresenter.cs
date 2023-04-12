using Asteroids.Game.Settings;
using UnityEngine;

namespace Asteroids.Game
{
    public sealed class BulletPresenter : IBulletPresenter
    {
        private readonly IUpdater _updater;
        private readonly IBulletModel _model;
        private readonly IBulletView _view;
        private readonly IBulletConfig _config;

        public BulletPresenter(IUpdater updater, IBulletModel model, IBulletView view, IBulletConfig config)
        {
            _updater = updater;
            _model = model;
            _view = view;
            _config = config;

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
            Move(deltaTime);
        }

        public void SetPosition(Vector3 position)
        {
            //_model.SetPosition(position);
        }

        public void SetRotate(Vector3 rotation)
        {
            //_model.Rotation = Quaternion.Euler(rotation).eulerAngles;
        }

        private void Move(float deltaTime)
        {
            //_model.Movement = _config.Speed * deltaTime * Vector2.up;
        }
    }
}