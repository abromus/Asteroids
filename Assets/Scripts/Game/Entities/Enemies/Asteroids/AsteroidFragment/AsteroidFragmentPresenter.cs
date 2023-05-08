using Asteroids.Core;
using Asteroids.Core.Services;
using Asteroids.Game.Settings;
using Bounds = Asteroids.Core.Bounds;

namespace Asteroids.Game
{
    public sealed class AsteroidFragmentPresenter : EnemyPresenter, IAsteroidFragmentPresenter
    {
        private readonly IAsteroidConfig _config;

        public AsteroidFragmentPresenter(IUpdater updater, IAsteroidFragmentModel model, IAsteroidFragmentView view, IAsteroidConfig config, Bounds bounds)
            : base(model, view, updater, bounds)
        {
            _config = config;
        }

        public void Init(Float3 position)
        {
            Model.Position.Value = position;

            Rotate();
        }

        public override void Tick(float deltaTime)
        {
            Move(_config.FragmentSpeed, deltaTime);

            CheckPosition();
        }

        public void TakeDamage(IDamaging damaging)
        {
            if (damaging is IBulletPresenter or ILaserPresenter)
                Destroy();
        }

        private void Rotate()
        {
            var angle = MathUtils.Value * MathUtils.FullAngle;
            var rotation = MathUtils.CalculateRotation(angle, Model.Rotation.Value);

            Model.Rotation.Value = rotation;
        }
    }
}
