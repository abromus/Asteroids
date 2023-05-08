using Asteroids.Core.Services;
using Asteroids.Game.Settings;

namespace Asteroids.Game
{
    public sealed class BulletPresenter : Projectile, IBulletPresenter
    {
        public BulletPresenter(IUpdater updater, IBulletModel model, IBulletView view, IBulletConfig config)
            : base(updater, model, view, config.MaxDistance, config.Speed) { }
    }
}
