using System;
using Asteroids.Core;
using Asteroids.Core.Services;
using Asteroids.Game.Settings;
using Bounds = Asteroids.Core.Bounds;

namespace Asteroids.Game
{
    public sealed class AsteroidPresenter : EnemyPresenter, IAsteroidPresenter
    {
        private readonly IAsteroidConfig _config;

        public Action<IAsteroidPresenter> Destroyed { get; set; }

        public AsteroidPresenter(IUpdater updater, IAsteroidModel model, IAsteroidView view, IAsteroidConfig config, Bounds bounds)
            : base(model, view, updater, bounds)
        {
            _config = config;
        }

        public void Init(Float3 position)
        {
            Model.Position.Value = position;

            Rotate();
        }

        public override void Destroy()
        {
            base.Destroy();

            Destroyed = null;
        }

        public override void Tick(float deltaTime)
        {
            Move(_config.Speed, deltaTime);

            CheckPosition();
        }

        public void TakeDamage(IDamaging damaging)
        {
            if (damaging is IBulletPresenter)
            {
                Destroyed?.SafeInvoke(this);

                Destroy();
            }
            else if (damaging is ILaserPresenter)
            {
                Destroy();
            }
        }

        private void Rotate()
        {
            var angle = MathUtils.Value * MathUtils.FullAngle;
            var rotation = MathUtils.CalculateRotation(angle, Model.Rotation.Value);

            Model.Rotation.Value = rotation;
        }
    }
}
