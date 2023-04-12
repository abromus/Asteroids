using Asteroids.Game.Settings;

namespace Asteroids.Game
{
    public sealed class FlyingSaucerPresenter : IFlyingSaucerPresenter
    {
        private readonly IUpdater _updater;
        private readonly IFlyingSaucerModel _model;
        private readonly IFlyingSaucerView _view;
        private readonly IFlyingSaucerConfig _config;

        public FlyingSaucerPresenter(IUpdater updater, IFlyingSaucerModel model, IFlyingSaucerView view, IFlyingSaucerConfig config)
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
