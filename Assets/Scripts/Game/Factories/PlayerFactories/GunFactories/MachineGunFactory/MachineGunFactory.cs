using Asteroids.Game.Settings;

namespace Asteroids.Game.Factory
{
    public sealed class MachineGunFactory : IMachineGunFactory
    {
        private readonly IUpdater _updater;
        private readonly IMachineGunViewFactory _viewFactory;
        private readonly IMachineGunConfig _config;
        private readonly IBulletFactory _bulletFactory;

        public MachineGunFactory(IUpdater updater, IMachineGunViewFactory viewFactory, IMachineGunConfig config, IBulletFactory bulletFactory)
        {
            _updater = updater;
            _viewFactory = viewFactory;
            _config = config;
            _bulletFactory = bulletFactory;
        }

        public IMachineGunPresenter Create()
        {
            var model = new MachineGunModel();
            var view = _viewFactory.Create();
            var presenter = new MachineGunPresenter(_updater, model, view, _config);

            return presenter;
        }
    }
}
