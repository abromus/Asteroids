using Asteroids.Core.Settings;

namespace Asteroids.Game
{
    public sealed class FlyingSaucerPresenter : IUpdatable
    {
        private readonly IUpdater _updater;
        private readonly FlyingSaucerModel _model;
        private readonly FlyingSaucerView _view;
        private readonly IFlyingSaucerConfig _config;

        public FlyingSaucerPresenter(IUpdater updater, FlyingSaucerModel model, FlyingSaucerView view, IFlyingSaucerConfig config)
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
