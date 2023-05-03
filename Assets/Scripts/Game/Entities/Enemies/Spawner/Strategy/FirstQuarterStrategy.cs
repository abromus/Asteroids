using Asteroids.Core;

namespace Asteroids.Game
{
    public sealed class FirstQuarterStrategy : IQuarterStrategy
    {
        private readonly Bounds _bounds;

        public FirstQuarterStrategy(Bounds bounds)
        {
            _bounds = bounds;
        }

        public Float3 CalculatePosition()
        {
            var half = 0.5f;

            var x = _bounds.Center.X + MathUtils.Value * _bounds.Size.X;
            var y = x > _bounds.Max.X ? MathUtils.Value * _bounds.Size.Y * half : _bounds.Min.Y;

            var position = x > _bounds.Max.X ? new Float3(_bounds.Max.X, y) : new Float3(x, y);

            return position;
        }
    }
}
