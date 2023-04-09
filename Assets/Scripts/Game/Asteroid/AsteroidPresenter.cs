using Asteroids.Core.Settings;

namespace Asteroids.Game
{
    public sealed class AsteroidPresenter : IUpdatable
    {
        private readonly IUpdater _updater;
        private readonly AsteroidModel _model;
        private readonly AsteroidView _view;
        private readonly IAsteroidConfig _config;

        public AsteroidPresenter(IUpdater updater, AsteroidModel model, AsteroidView view, IAsteroidConfig config)
        {
            _updater = updater;
            _model = model;
            _view = view;
            _config = config;

            _model.OnMovementChanged += _view.Move;
            _model.OnRotationChanged += _view.Rotate;
        }

        public void Enable()
        {
            _updater.Add(this);
        }

        public void Destroy()
        {
            Disable();

            _view.StartDestroy();
        }

        public void Disable()
        {
            _updater.Remove(this);
        }

        public void Tick(float deltaTime)
        {
        }
    }
}
