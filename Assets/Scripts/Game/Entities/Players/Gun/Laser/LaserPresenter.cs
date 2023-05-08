using Asteroids.Core.Services;
using Asteroids.Game.Settings;

namespace Asteroids.Game
{
    public sealed class LaserPresenter : Projectile, ILaserPresenter
    {
        public LaserPresenter(IUpdater updater, ILaserModel model, ILaserView view, ILaserConfig config)
            : base(updater, model, view, config.MaxDistance, config.Speed) { }
    }
}
