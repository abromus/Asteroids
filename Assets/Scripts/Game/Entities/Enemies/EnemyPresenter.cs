using Asteroids.Core;
using Asteroids.Core.Services;
using Bounds = Asteroids.Core.Bounds;

namespace Asteroids.Game
{
    public abstract class EnemyPresenter : IPresenter
    {
        private Float3 _previousPosition;
        private Float3 _offset;
        private bool _isDestroyed;

        private readonly IUpdater _updater;
        private readonly Bounds _bounds;

        protected readonly IModel Model;
        protected readonly IView View;

        public bool IsDestroyed => _isDestroyed;

        public Float3 Position => Model.Position.Value;

        public EnemyPresenter(IModel model, IView view, IUpdater updater, Bounds bounds)
        {
            Model = model;
            View = view;
            _updater = updater;
            _bounds = bounds;
        }

        public abstract void Tick(float deltaTime);

        public virtual void Destroy()
        {
            Clear();

            _isDestroyed = true;
        }

        public void Enable()
        {
            Model.Position.OnChanged += View.Move;
            Model.Rotation.OnChanged += View.Rotate;

            _updater.Add(this);

            View.Activate();
        }

        public void Disable()
        {
            Clear();
        }

        public void Clear()
        {
            _updater.Remove(this);

            Model.Position.OnChanged -= View.Move;
            Model.Rotation.OnChanged -= View.Rotate;

            Model.Position.Value = Float3.Zero;
            Model.Rotation.Value = Float3.Zero;

            View?.Deactivate();

            _isDestroyed = false;
        }

        protected void Move(float speed, float deltaTime)
        {
            var direction = MathUtils.TransformDirection(Model.Rotation.Value.Z);
            var delta = speed * deltaTime * direction;
            var modelPosition = MathUtils.CorrectPosition(Model.Position.Value + delta, _bounds);

            _previousPosition = Model.Position.Value;
            _offset = delta;
            Model.Position.Value = modelPosition;
        }

        protected void CheckPosition()
        {
            if (_previousPosition + _offset != Model.Position.Value)
                Destroy();
        }
    }
}
