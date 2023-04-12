using Asteroids.Game.Settings;

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

            //_model.Position.OnChanged += _view.ChangePosition;
            //_model.Rotation.OnChanged += _view.Rotate;
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
    }
}
