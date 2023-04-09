using Asteroids.Game.Settings;

namespace Asteroids.Game
{
    public sealed class MachineGunPresenter : IMachineGunPresenter
    {
        private readonly IUpdater _updater;
        private readonly IMachineGunModel _model;
        private readonly IMachineGunView _view;
        private readonly IMachineGunConfig _config;

        public MachineGunPresenter(IUpdater updater, IMachineGunModel model, IMachineGunView view, IMachineGunConfig config)
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
