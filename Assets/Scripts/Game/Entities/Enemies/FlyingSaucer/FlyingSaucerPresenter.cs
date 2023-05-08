using Asteroids.Core;
using Asteroids.Core.Services;
using Asteroids.Game.Settings;
using Bounds = Asteroids.Core.Bounds;

namespace Asteroids.Game
{
    public sealed class FlyingSaucerPresenter : EnemyPresenter, IFlyingSaucerPresenter
    {
        private IShipPresenter _shipPresenter;

        private readonly IFlyingSaucerConfig _config;

        public FlyingSaucerPresenter(IUpdater updater, IFlyingSaucerModel model, IFlyingSaucerView view, IFlyingSaucerConfig config, Bounds bounds)
            : base(model, view, updater, bounds)
        {
            _config = config;
        }

        public override void Tick(float deltaTime)
        {
            Rotate();

            Move(deltaTime);

            CheckPosition();
        }

        public void Init(Float3 position, IShipPresenter shipPresenter)
        {
            _shipPresenter = shipPresenter;

            Model.Position.Value = position;

            var first = _shipPresenter.Position.X < Model.Position.Value.X ? Model.Position.Value : _shipPresenter.Position;
            var second = _shipPresenter.Position.X < Model.Position.Value.X ? _shipPresenter.Position : Model.Position.Value;

            var deltaPosition = first - second;
            var angle = MathUtils.CalculateAngle(Float3.Up, deltaPosition);

            var rotation = MathUtils.CalculateRotation(-angle, Float3.Zero);

            Model.Rotation.Value = rotation;
            View.Rotate(rotation);
        }

        public void TakeDamage(IDamaging damaging)
        {
            if (damaging is IBulletPresenter or ILaserPresenter)
                Destroy();
        }

        private void Rotate()
        {
            var destroyDistance = 0.5f;

            var first = _shipPresenter.Position.X < Model.Position.Value.X ? Model.Position.Value : _shipPresenter.Position;
            var second = _shipPresenter.Position.X < Model.Position.Value.X ? _shipPresenter.Position : Model.Position.Value;

            if (MathUtils.Distance(first, second) <= destroyDistance)
                return;

            first = _shipPresenter.Position.X < Model.Position.Value.X ? Model.Position.Value : _shipPresenter.Position;
            second = _shipPresenter.Position.X < Model.Position.Value.X ? _shipPresenter.Position : Model.Position.Value;

            var deltaPosition = first - second;
            var angle = MathUtils.CalculateAngle(Float3.Up, deltaPosition);
            var resultAngle = _shipPresenter.Position.X < Model.Position.Value.X ? MathUtils.HalfAngle - angle : -angle;
            var rotation = MathUtils.CalculateRotation(resultAngle, Float3.Zero);

            Model.Rotation.Value = rotation;
        }

        private void Move(float deltaTime)
        {
            if (IsDestroyed)
                return;

            Move(_config.Speed, deltaTime);
        }
    }
}
